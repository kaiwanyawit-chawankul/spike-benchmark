using System.Collections.Generic;
using Flee;
using Flee.PublicTypes;
using static SpikeBenchmark.Benchmark;

namespace SpikeBenchmark
{
    public class FleeRuleEngine : RuleEngine
    {
        public override bool Eval(string expression, Dictionary<string, bool> variables)
        {
            string toFleeExpression = expression.Replace("&&","&").Replace("||", "|");
            ExpressionContext context = new ExpressionContext();
            VariableCollection contextVariables = context.Variables;
            foreach (var variable in variables)
            {
                contextVariables.Add(variable.Key, variable.Value);
            }
                        
            IGenericExpression<bool> e = context.CompileGeneric<bool>(toFleeExpression);
            return e.Evaluate();
        }
    }
}
