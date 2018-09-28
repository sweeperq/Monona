using System;
using System.Linq.Expressions;

namespace Monona.Core.Specifications
{
    public class SortSpecification<T>
        where T : class
    {
        public SortSpecification(string fieldName, SortDirection direction = SortDirection.Ascending)
        {
            fieldName.ThrowIfEmpty(nameof(fieldName));
            var paramExpr = Expression.Parameter(typeof(T));
            var propExpr = Expression.Convert(Expression.PropertyOrField(paramExpr, fieldName), typeof(object));
            var expr = Expression.Lambda<Func<T, object>>(propExpr, paramExpr);
            Field = expr;
            Direction = direction;
        }

        public SortSpecification(Expression<Func<T,object>> field, SortDirection direction = SortDirection.Ascending)
        {
            field.ThrowIfNull(nameof(field));
            Field = field;
            Direction = direction;
        }

        public Expression<Func<T,object>> Field { get; }

        public SortDirection Direction { get; }
        
    }
}
