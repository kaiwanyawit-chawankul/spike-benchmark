using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SpikeBenchmark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net472, baseline: true)]
    //[SimpleJob(RuntimeMoniker.Net80)]
    public class Benchmark
    {
        NcalcRuleEngine ncalcRuleEngine;
        DataTableRuleEngine dataTableRuleEngine;
        LinqRuleEngine linqRuleEngine;

        FleeRuleEngine fleeRuleEngine;

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

        //[Params("BUNA && NOBAG","BUNA && (NOBAG || NOSEAT)","BUNA && (BAG1 || BAG2 || BAG3)")]
        [Params("BUNA && NOBAG")]
        public string Expression;

        //[Params(100, 1000, 10000, 50000)]
        [Params(10)]
        public int Times;

        [GlobalSetup]
        public void Setup()
        {
            ncalcRuleEngine = new NcalcRuleEngine();
            dataTableRuleEngine = new DataTableRuleEngine();
            linqRuleEngine = new LinqRuleEngine();
            fleeRuleEngine = new FleeRuleEngine();
        }

        [Benchmark]
        public void NcalcRuleEngine()
        {
            for (int i = 0; i < Times; i++)
            {
                ncalcRuleEngine.Eval(Expression, variables);
            }
        }

        [Benchmark]
        public void DataTableRuleEngine()
        {
            for (int i = 0; i < Times; i++)
            {
                dataTableRuleEngine.Eval(Expression, variables);
            }
        }

        [Benchmark]
        public void LinqRuleEngine()
        {
            for (int i = 0; i < Times; i++)
            {
                linqRuleEngine.Eval(Expression, variables);
            }
        }

        [Benchmark]
        public void FleeRuleEngine()
        {
            for (int i = 0; i < Times; i++)
            {
                fleeRuleEngine.Eval(Expression, variables);
            }
        }
        public class RuleEngine
        {
            public virtual bool Eval(string expression, Dictionary<string, bool> variables)
            {
                throw new NotImplementedException();
            }
        }
    }
}
