using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Linq2GitHub
{
    class QueryTranslator : ExpressionVisitor
    {
        string queryMethod;
        string[] parameters;

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(IQueryable) && node.Method.Name == "OrderBy")
            {
                var repo = node.Arguments[0];
                var argument2 = node.Arguments[1];
            }
            throw new NotSupportedException(string.Format("The method '{0}' is not supported", node.Method.Name));
        }
    }
}
