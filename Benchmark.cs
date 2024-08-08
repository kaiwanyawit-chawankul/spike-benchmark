using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SpikeBenchmark
{
    [MemoryDiagnoser]
    // [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class Benchmark
    {
        NcalcRuleEngine ncalcRuleEngine;
        DataTableRuleEngine dataTableRuleEngine;
        LinqRuleEngine linqRuleEngine;

        Dictionary<string, bool> variables = new Dictionary<string, bool>()
        {
            { "BUNA", true },
            { "NOBAG", true },
            { "SEAT1", false },
            { "NOSEAT", false },
            { "BAG1", true },
            { "BAG2", false },
            { "BAG3", false }
        };

        [Params("BUNA && NOBAG","BUNA && (NOBAG || NOSEAT)","BUNA && (BAG1 || BAG2 || BAG3)")]
        public string Expression;

            [GlobalSetup]
            public void Setup()
            {
ncalcRuleEngine = new NcalcRuleEngine();
dataTableRuleEngine = new DataTableRuleEngine();
linqRuleEngine = new LinqRuleEngine();

            }

            [Benchmark]
            public void NcalcRuleEngine()  => ncalcRuleEngine.Eval(Expression, variables);

            [Benchmark]
            public void DataTableRuleEngine() => dataTableRuleEngine.Eval(Expression, variables);

            [Benchmark]
            public void LinqRuleEngine() => linqRuleEngine.Eval(Expression, variables);

    public class RuleEngine
    {
        public virtual bool Eval(string expression, Dictionary<string, bool> variables)
        {
            throw new NotImplementedException();
        }
    }
}
}


