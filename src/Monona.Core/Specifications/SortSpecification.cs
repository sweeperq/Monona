using System;
using System.Linq.Expressions;

namespace Monona.Core.Specifications
{
    public class SortSpecification<T>
        where T : class
    {
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
