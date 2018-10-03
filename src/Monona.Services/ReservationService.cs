using Microsoft.EntityFrameworkCore;
using Monona.Core.Entities;
using Monona.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monona.Services
{
    public class ReservationService : GenericService<Reservation, int>
    {
        public ReservationService(MononaDbContext context, AutoMapper.IMapper mapper) : base(context, mapper)
        {
        }

        public override ServiceResult Create(Reservation entity)
        {
            var result = ValidateBeforeCreate(entity);
            if (result.Succeeded)
            {
                using (var trans = Context.Database.BeginTransaction())
                {
                    Entities.Add(entity);
                    Commit(result);
                    if (result.Succeeded)
                    {
                        try
                        {
                            Context.Database.ExecuteSqlCommand("UPDATE ProductInventory SET ReservedQuantity = ReservedQuantity + {0}, AvailableQuantity = AvailableQuantity - {0}, PotentialQuantity = PotentialQuantity - {0} WHERE ProductId = {1}", entity.Quantity, entity.ProductId);
                            trans.Commit();
                        }
                        catch(Exception ex)
                        {
                            result.AddError(ex.Message);
                            trans.Rollback();
                        }
                    }
                }
            }
            return result;
        }

        public override ServiceResult Update(Reservation entity)
        {
            var result = ValidateBeforeUpdate(entity);
            if (result.Succeeded)
            {
                using (var trans = Context.Database.BeginTransaction())
                {
                    Entities.Update(entity);
                    int originalQty = (int)Context.Entry(entity).OriginalValues["Quantity"];
                    int changeQty = entity.Quantity - originalQty;
                    Commit(result);
                    if (result.Succeeded)
                    {
                        try
                        {
                            if (changeQty != 0)
                            {
                                Context.Database.ExecuteSqlCommand("UPDATE ProductInventory SET ReservedQuantity = ReservedQuantity + {0}, AvailableQuantity = AvailableQuantity - {0}, PotentialQuantity = PotentialQuantity - {0} WHERE ProductId = {1}", changeQty, entity.ProductId);
                            }
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            result.AddError(ex.Message);
                            trans.Rollback();
                        }
                    }
                }                
            }
            return result;
        }

        public override ServiceResult Delete(Reservation entity)
        {
            var result = ValidateBeforeDelete(entity);
            if (result.Succeeded)
            {
                using (var trans = Context.Database.BeginTransaction())
                {
                    Entities.Remove(entity);
                    int originalQty = (int)Context.Entry(entity).OriginalValues["Quantity"];
                    Commit(result);
                    if (result.Succeeded)
                    {
                        try
                        {
                            if (originalQty > 0)
                            {
                                Context.Database.ExecuteSqlCommand("UPDATE ProductInventory SET ReservedQuantity = ReservedQuantity - {0}, AvailableQuantity = AvailableQuantity + {0}, PotentialQuantity = PotentialQuantity + {0} WHERE ProductId = {1}", entity.Quantity, entity.ProductId);
                            }
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            result.AddError(ex.Message);
                            trans.Rollback();
                        }
                    }
                }
            }
            return result;
        }
    }
}
