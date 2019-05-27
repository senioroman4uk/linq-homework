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
                var lambda = (LambdaExpression)RemoveQuotes(node.Arguments[1]);
                var lambdaBody = (MemberExpression)RemoveQuotes(lambda.Body);
                queryMethod = lambda.Parameters[0].Name;
                var k = lambdaBody.Member.Name;
            }
            //throw new NotSupportedException(string.Format("The method '{0}' is not supported", node.Method.Name));
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
