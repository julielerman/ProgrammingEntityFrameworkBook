Programming Entity Framework 2nd Edition
by Julia Lerman
www.ProgrammingEntityFramework.com
Chapter 11, Customizing Entities


This sample contains a C# Solution which contains two projects that can be used to test some Chapter 11 code. 

1) The BreakAway model along with new partial classes to add various customizations to generated entity classes.

2) A console app project that hits a few of those customizations as well as builds the forecast data used by the Lodgings' materialization event.

The current connection string in the project's app.points to a local sql server 2008 database. If you are using SQL Server Express, you should change the data source from . to .\SQLExpress.

Julie Lerman
thedatafarm.com/blog
twitter.com/julielerman