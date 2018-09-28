using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monona.Core.Entities;
using Monona.Core.Pagination;
using Monona.Core.Specifications;
using Monona.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Monona.Services
{
    public abstract class BaseService<T, TKey>
        where TKey : IEquatable<TKey>
        where T : class, IEntity<TKey>
    {
        public BaseService(MononaDbContext context, IMapper mapper)
        {
            Context = context;
            Entities = Context.Set<T>();
            Mapper = mapper;
        }

        public bool Persist { get; set; } = true;

        protected MononaDbContext Context { get; }

        protected DbSet<T> Entities { get; }

        protected IMapper Mapper { get; }

        protected IQueryable<T> Query
        {
            get { return Entities; }
        }

        public virtual T GetById(TKey id, params Expression<Func<T,object>>[] includes)
        {
            var criteria = new Specification<T>(x => id.Equals(x.Id));
            return FindSingle(criteria, includes);
        }

        public virtual TDto GetByIdDto<TDto>(TKey id)
        {
            var criteria = new Specification<T>(x => id.Equals(x.Id));
            return FindSingleDto<TDto>(criteria);
        }

        public virtual IEnumerable<T> GetAll(SortSpecification<T>[] sort, params Expression<Func<T, object>>[] includes)
        {
            return FindMany(null, sort, includes);
        }

        public virtual PagedList<T> GetAllPaged(int page, int pageSize, SortSpecification<T>[] sort, params Expression<Func<T,object>>[] includes)
        {
            return FindManyPaged(page, pageSize, null, sort, includes);
        }

        public virtual IEnumerable<TDto> GetAllDto<TDto>(SortSpecification<T>[] sort)
        {
            return FindManyDto<TDto>(null, sort);
        }

        public virtual PagedList<TDto> GetAllDtoPaged<TDto>(int page, int pageSize, SortSpecification<T>[] sort)
        {
            return FindManyDtoPaged<TDto>(page, pageSize, null, sort);
        }

        public virtual T FindSingle(Specification<T> criteria, params Expression<Func<T,object>>[] includes)
        {
            return FindInternal(criteria, null, includes).FirstOrDefault();
        }

        public virtual TDto FindSingleDto<TDto>(Specification<T> criteria)
        {
            return FindInternalDto<TDto>(criteria, null).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindMany(Specification<T> criteria, SortSpecification<T>[] sort, params Expression<Func<T,object>>[] includes)
        {
            return FindInternal(criteria, sort, includes).ToList();
        }

        public virtual PagedList<T> FindManyPaged(int page, int pageSize, Specification<T> criteria, SortSpecification<T>[] sort, params Expression<Func<T, object>>[] includes)
        {
            return FindInternal(criteria, sort, includes).ToPagedList(page, pageSize);
        }

        public virtual IEnumerable<TDto> FindManyDto<TDto>(Specification<T> criteria, SortSpecification<T>[] sort)
        {
            return FindInternalDto<TDto>(criteria, sort).ToList();
        }

        public virtual PagedList<TDto> FindManyDtoPaged<TDto>(int page, int pageSize, Specification<T> criteria, SortSpecification<T>[] sort)
        {
            return FindInternalDto<TDto>(criteria, sort).ToPagedList(page, pageSize);
        }

        protected virtual IQueryable<T> FindInternal(Specification<T> criteria, SortSpecification<T>[] sort, params Expression<Func<T, object>>[] includes)
        {
            var query = Query;
            if (includes != null)
            {
                foreach(var i in includes)
                {
                    query = query.Include(i);
                }
            }
            if (criteria != null && criteria.Criteria != null)
            {
                query = query.Where(criteria.Criteria);
            }
            if (sort != null)
            {
                IOrderedQueryable<T> orderedQuery = null;
                foreach(var s in sort)
                {
                    if (orderedQuery == null)
                    {
                        if (s.Direction == SortDirection.Descending)
                        {
                            orderedQuery = query.OrderByDescending(s.Field);
                        }
                        else
                        {
                            orderedQuery = query.OrderBy(s.Field);
                        }
                    }
                    else if (s.Direction == SortDirection.Descending)
                    {
                        orderedQuery = orderedQuery.ThenByDescending(s.Field);
                    }
                    else
                    {
                        orderedQuery = orderedQuery.ThenBy(s.Field);
                    }
                }
                if (orderedQuery != null)
                {
                    query = orderedQuery;
                }
            }
            return query;
        }

        public virtual IQueryable<TDto> FindInternalDto<TDto>(Specification<T> criteria, SortSpecification<T>[] sort)
        {
            return FindInternal(criteria, sort).Select(e => this.Mapper.Map<TDto>(e));
        }


        public virtual ServiceResult Create(T entity)
        {
            var result = ValidateBeforeCreate(entity);
            if (result.Succeeded)
            {
                Entities.Add(entity);
                Commit(result);
            }
            return result;
        }

        public virtual ServiceResult<T> CreateFromDto<TDto>(TDto dto)
            where TDto : class
        {
            dto.ThrowIfNull(nameof(dto));
            var result = new ServiceResult<T>();
            var entity = this.Mapper.Map<T>(dto);
            result.MergeResult(Create(entity));
            if (result.Succeeded)
                result.Data = entity;
            return result;
        }

        public virtual ServiceResult Update(T entity)
        {
            var result = ValidateBeforeUpdate(entity);
            if (result.Succeeded)
            {
                Entities.Update(entity);
                Commit(result);
            }
            return result;
        }

        public virtual ServiceResult<T> UpdateFromDto<TDto>(TKey id, TDto dto)
            where TDto : class
        {
            dto.ThrowIfNull(nameof(dto));
            var result = new ServiceResult<T>();
            var entity = GetById(id);
            this.Mapper.Map<TDto, T>(dto, entity);
            result.MergeResult(Update(entity));
            if (result.Succeeded)
                result.Data = entity;
            return result;
        }

        public virtual ServiceResult DeleteById(TKey id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }

        public virtual ServiceResult Delete(T entity)
        {
            var result = ValidateBeforeDelete(entity);
            if (result.Succeeded)
            {
                Entities.Remove(entity);
                Commit(result);
            }
            return result;
        }

        protected virtual ServiceResult ValidateBeforeCreate(T entity)
        {
            var result = ValidateEntity(entity);
            return result;
        }

        protected virtual ServiceResult ValidateBeforeUpdate(T entity)
        {
            var result = ValidateEntity(entity);
            return result;
        }

        protected virtual ServiceResult ValidateBeforeDelete(T entity)
        {
            return new ServiceResult();
        }

        protected virtual ServiceResult ValidateEntity(T entity)
        {
            entity.ThrowIfNull(nameof(entity));
            var result = new ServiceResult();
            var valResults = new List<ValidationResult>();
            var valContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity, null, null);
            if (!Validator.TryValidateObject(entity, valContext, valResults, true))
            {
                valResults.ForEach(error => result.AddError(error.ErrorMessage, error.MemberNames.FirstOrDefault()));
            }
            return result;
        }

        

        protected void Commit(ServiceResult result = null)
        {
            if (Persist)
            {
                try
                {
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (result == null)
                    {
                        throw ex;
                    }
                    else
                    {
                        result.AddError(ex.Message);
                    }
                }
            }
        }
    }
}
