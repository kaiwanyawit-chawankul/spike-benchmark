using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using static SpikeBenchmark.Benchmark;

namespace SpikeBenchmark
{
    public class LinqRuleEngine : RuleEngine
    {
        public override bool Eval(string expression, Dictionary<string, bool> variables){
            var parameter = Expression.Parameter(typeof(Dictionary<string, bool>), "variables");
            var _evaluator = DynamicExpressionParser.ParseLambda(new[] { parameter }, typeof(bool), expression);

            // Compile and invoke the expression
            var compiledExpression = (Func<Dictionary<string, bool>, bool>)_evaluator.Compile();
            return compiledExpression(variables);
        }
    }
}


