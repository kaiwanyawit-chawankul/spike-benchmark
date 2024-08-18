https://benchmarkdotnet.org/articles/faq.html



dotnet run --configuration release

https://csharpier.com/docs/Pre-commit

# result for net4.7.2

| Method              | Expression    | Times | Mean        | Error     | StdDev    | Median      | Ratio | RatioSD | Gen0     | Gen1    | Allocated | Alloc Ratio |
|-------------------- |-------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|---------:|--------:|----------:|------------:|
| NcalcRuleEngine     | BUNA && NOBAG | 10    |   208.86 us | 12.171 us | 33.523 us |   195.43 us |  1.02 |    0.21 |  82.5195 |       - |  13.24 KB |        1.00 |
|                     |               |       |             |           |           |             |       |         |          |         |           |             |
| DataTableRuleEngine | BUNA && NOBAG | 10    |    38.10 us |  3.122 us |  9.008 us |    33.57 us |  1.04 |    0.31 |  94.2993 |       - |   15.1 KB |        1.00 |
|                     |               |       |             |           |           |             |       |         |          |         |           |             |
| LinqRuleEngine      | BUNA && NOBAG | 10    | 1,387.17 us | 30.297 us | 89.333 us | 1,378.08 us |  1.00 |    0.09 | 408.2031 | 33.2031 |   65.6 KB |        1.00 |
|                     |               |       |             |           |           |             |       |         |          |         |           |             |
| FleeRuleEngine      | BUNA && NOBAG | 10    |          NA |        NA |        NA |          NA |     ? |       ? |       NA |      NA |        NA |           ? |