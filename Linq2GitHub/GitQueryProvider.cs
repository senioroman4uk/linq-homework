using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;

namespace Linq2GitHub
{
    class GitQueryProvider : IQueryProvider
    {
        HttpClient _httpClient;

        public GitQueryProvider()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "bearer",
                "db537d9a3a4d21e02cff1e3df79f2196fb15abd5");
        }
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new GitQueryable<TElement>(this, expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
