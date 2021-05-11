Programming Entity Framework 2nd Edition
by Julia Lerman
www.ProgrammingEntityFramework.com
Chapter 20, Real World Apps: Connections, Transactions, Performance, and More

Code for declaring, compiling and invoking a pre-compiled LINQ to Entities query.

This sample contains a C# Solution which contains two projects. 

1) The current version of the BreakAway model with further customizations to the entities and the required extension methods.

2) A console app

The current connection string in the console project's app.config points to a local sql server 2008 database. If you are using SQL Server Express, you should change the data source from . to .\SQLExpress.

Julie Lerman
thedatafarm.com/blog
twitter.com/julielerman