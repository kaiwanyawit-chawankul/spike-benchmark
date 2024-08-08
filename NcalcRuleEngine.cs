using System.Collections.Generic;
using NCalc;
using static SpikeBenchmark.Benchmark;

namespace SpikeBenchmark
{
    public class NcalcRuleEngine : RuleEngine
    {
        public override bool Eval(string expression, Dictionary<string, bool> variables)
        {
            var _evaluator = new Expression(expression);
            foreach (var variable in variables)
            {
                _evaluator.Parameters[variable.Key] = variable.Value;
            }

            return (bool)_evaluator.Evaluate();
        }
    }
}
