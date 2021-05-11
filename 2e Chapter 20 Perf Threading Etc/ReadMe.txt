Programming Entity Framework 2nd Edition
by Julia Lerman
www.ProgrammingEntityFramework.com
Chapter 20, Real World Apps: Connections, Transactions, Performance, and More

Project with threading examples and another project with my performance testing code.

Note that I did a *lot* of exploration with teh perf tests and I have code that I commented and uncommented etc. Hopefully the code will just give you a solid idea of what how I did things. Lately, I've started leaning more on profiling tools (e.g., built into Visual Studio as well as Red-Gate's ANTs profiler) rather than tangling with all of the stopwatch nonsense that is in these code samples. Just a thought...

This sample contains a C# Solution which contains threeprojects. 

1) The current version of the BreakAway model with further customizations to the entities and the required extension methods.

2) A console app with threading examples.

3) A console app with various performance comparison tests.

The current connection string in the console projects' app.config points to a local sql server 2008 database. If you are using SQL Server Express, you should change the data source from . to .\SQLExpress.

Julie Lerman
thedatafarm.com/blog
twitter.com/julielerman