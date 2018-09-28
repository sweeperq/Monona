using System;
using System.Linq.Expressions;

namespace Monona.Core.Specifications
{
    public class Specification<T>
        where T : class
    {
        public Specification()
        {
            Criteria = null;
        }

        public Specification(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; protected set; }

        public void And(Expression<Func<T,bool>> criteria)
        {
            if (Criteria == null)
            {
                Criteria = criteria;
            }
            else
            {
                var paramExpr = Expression.Parameter(typeof(T), "e");
                var expr = Expression.AndAlso(Criteria.Body, criteria.Body);
                expr = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(expr);
                Criteria = Expression.Lambda<Func<T, bool>>(expr, paramExpr);
            }
        }

        public void Or(Expression<Func<T,bool>> criteria)
        {
            if (Criteria == null)
            {
                Criteria = criteria;
            }
            else
            {
                var paramExpr = Expression.Parameter(typeof(T), "e");
                var expr = Expression.OrElse(Criteria.Body, criteria.Body);
                expr = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(expr);
                Criteria = Expression.Lambda<Func<T, bool>>(expr, paramExpr);
            }
        }
    }
}
