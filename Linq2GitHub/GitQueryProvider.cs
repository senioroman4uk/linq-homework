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
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "bearer",
                "1a9a4c67c4ed545ef216df3c130f445f60cfaff4");
        }
        public IQueryable CreateQuery(Expression expression)
        {
            return new GitQueryable(this, expression);
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
            _queryTranslator.Visit(expression);
            HttpResponseMessage response = _httpClient.GetAsync(_queryTranslator.UriBuilder.ToString()).Result;
            var result = response.Content.ReadAsAsync<IEnumerable<RepoModel>>().Result;
            return (TResult)result;
        }

        public Expression RemoveQuotes(Expression expr)
        {
            while (expr.NodeType == ExpressionType.Quote)
            {
                expr = ((UnaryExpression)expr).Operand;
            }
            return expr;
        }
    }
}
