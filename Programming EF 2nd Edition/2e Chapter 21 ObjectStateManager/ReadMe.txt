Programming Entity Framework 2nd Edition
by Julia Lerman
www.ProgrammingEntityFramework.com
Chapter 21, Manipulating Entities with ObjectStateManager and MetadataWorkspace


This project demonstrates the ObjectStateVisualizer, the sample for creating Entity SQL dynamically (and generically) and the example which builds an entity graph dynamically.

This sample contains a C# Solution which contains threeprojects. 

1) The current version of the BreakAway model with further customizations to the entities and the required extension methods.

2) A console app that runs all three examples.

3) The ObjectStateVisualizer project.

Note that although the model classes in this sample code are generated using the default template (which creates EntityObjects) I have run all of the samples against generated POCOs as well. 

The current connection string in the console projects' app.config points to a local sql server 2008 database. If you are using SQL Server Express, you should change the data source from . to .\SQLExpress.

Julie Lerman
thedatafarm.com/blog
twitter.com/julielerman