using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace Linq2GitHub
{
    class QueryTranslator : ExpressionVisitor
    {
        UriBuilder _uriBuilder;
        NameValueCollection _query;

        public UriBuilder UriBuilder
        {
            get
            {
                _uriBuilder.Query = _query.ToString();
                return _uriBuilder;
            }
        }
        public QueryTranslator()
        {
            _query = HttpUtility.ParseQueryString(string.Empty);
            _uriBuilder = new UriBuilder()
            {
                Host = "api.github.com",
                Scheme = "https",
                Path = "user/repos",
            };
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(Queryable))
            {
                Visit(node.Arguments[0]);
                var lambda = (LambdaExpression)RemoveQuotes(node.Arguments[1]);

                switch (node.Method.Name)
                {
                    case "OrderByDescending":
                        {
                            _query["direction"] = "desc";                            
                            break;
                        }
                    case "OrderBy":
                        {
                            _query["direction"] = "asc";
                            break;
                        }
                    case "Where":
                        {
                            break;
                        }
                    default:
                        {
                            throw new NotSupportedException(string.Format("The method '{0}' is not supported", node.Method.Name));
                        }
                }
                    
                Visit(lambda.Body);
                return node;
            }   
            
            throw new NotSupportedException(
                string.Format(
                    "The method with declaring type '{0}' is not supported", 
                    node.Method.DeclaringType));
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Equal)
            {
                var constantExpression = (ConstantExpression)node.Right;
                _query["type"] = constantExpression.Value.ToString();
            }
            else
                throw new NotSupportedException();
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            var filterCriteria = node.Member.Name;
            switch (filterCriteria)
            {
                case "UpdatedDate":
                    {
                        _query["sort"] = "updated";
                        break;
                    }
                case "PushedDate":
                    {
                        _query["sort"] = "pushed";
                        break;
                    }
                case "FullName":
                    {
                        _query["sort"] = "full_name";
                        break;
                    }
                case "CreatedDate":
                default:
                    {
                        _query["sort"] = "created";
                        break;
                    }
            }
            return node;
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
