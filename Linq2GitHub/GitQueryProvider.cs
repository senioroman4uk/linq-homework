using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Linq2GitHub
{
    class GitQueryProvider : IQueryProvider
    {
        HttpClient _httpClient;
        QueryTranslator _queryTranslator;
        public GitQueryProvider(QueryTranslator queryTranslator)
        {
            _queryTranslator = queryTranslator;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "bearer",
                "754cad0e57d1ada2530b6123539c99c68a734759");
        }
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return (IQueryable<TElement>)new GitQueryable(this, expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            HttpResponseMessage response = _httpClient.GetAsync("user/repos").Result;
            var result = response.Content.ReadAsAsync<IEnumerable<RepoModel>>().Result;
            return (TResult)result;
        }
    }
}
