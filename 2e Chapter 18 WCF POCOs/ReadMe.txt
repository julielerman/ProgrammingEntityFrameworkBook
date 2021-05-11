Programming Entity Framework 2nd Edition
by Julia Lerman
www.ProgrammingEntityFramework.com
Chapter 18, Using POCOs and Self-Tracking Entities in WCF Servicess

This is the custom WCF service solution that makes up the bulk of the chapter.

This sample contains a C# Solution which contains three projects that define the application built in Chapter 17. 

1) The current version of the BreakAway model with further customizations to the entities and the required extension methods.

2) The POCO template and the POCO classes generated from the model.

3) The POCO State project to add state info to the POCOs.

4) The WCF Service project

5) The Console App UI  client

The current connection string in the WCF Service project's web.config points to a local sql server 2008 database. If you are using SQL Server Express, you should change the data source from . to .\SQLExpress.

Julie Lerman
thedatafarm.com/blog
twitter.com/julielerman