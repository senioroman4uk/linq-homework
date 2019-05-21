using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Linq2GitHub
{
    class GitQueryable<T> : IQueryable<T>
    {
        public GitQueryable(IQueryProvider queryProvider, Expression expression)
        {
            Provider = queryProvider ?? throw new ArgumentNullException();
            Expression = expression ?? Expression.Constant(this);
        }
        public Type ElementType => typeof(T);

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = Provider.Execute<IEnumerable<T>>(this.Expression).GetEnumerator();
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator enumerator = Provider.Execute<IEnumerable>(this.Expression).GetEnumerator();
            return enumerator;
        }
    }
}
