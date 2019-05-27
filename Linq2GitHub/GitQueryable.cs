using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Linq2GitHub
{
    class GitQueryable : IOrderedQueryable<RepoModel>
    {
        public GitQueryable(IQueryProvider queryProvider, Expression expression)
        {
            Provider = queryProvider ?? throw new ArgumentNullException();
            Expression = expression ?? Expression.Constant(this);
        }
        public Type ElementType => typeof(RepoModel);

        public Expression Expression { get; }

        public IQueryProvider Provider { get; }

        public IEnumerator<RepoModel> GetEnumerator()
        {
            var result = Provider.Execute<IEnumerable<RepoModel>>(this.Expression) ?? new List<RepoModel>();
            return result.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var enumerator = Provider.Execute<IEnumerable>(this.Expression).GetEnumerator();
            return enumerator;
        }
    }
}
