using System.Collections.Generic;
using System.Data;
using static SpikeBenchmark.Benchmark;

namespace SpikeBenchmark
{
    public class DataTableRuleEngine : RuleEngine
    {
        DataTable _ruleEvaluator = new DataTable();

        public override bool Eval(string expression, Dictionary<string, bool> variables)
        {
            var processedScript = expression;
            foreach (var key in variables.Keys)
            {
                processedScript = processedScript.Replace(key, variables[key] ? "true" : "false");
            }
            processedScript = processedScript.Replace("&&", " AND ");
            processedScript = processedScript.Replace("||", " OR ");
            processedScript = processedScript.Replace("!", " NOT ");
            processedScript = processedScript.Replace("  ", " ");

            var result = _ruleEvaluator.Compute(processedScript, null);
            return (bool)result;
        }
    }
}
