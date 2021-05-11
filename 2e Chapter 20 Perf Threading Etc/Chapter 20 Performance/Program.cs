using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using BAGA;

//using BAGA;


namespace Chapter20ConsolePerf
{
  class Program
  {
    static void Main()
    {
      
      PerfTests();
      TimeL2E();
      TimeObjectQuery();
      LinqToEntitiesTest();

    }

    
    private static void TimeL2E()
    {
      var sw = new System.Diagnostics.Stopwatch();
      sw.Start();
      using (var context = new AWEntities())
      {

        var custList = (from c in context.AWCustomers select c).ToList();

      }
      sw.Stop();
      Console.WriteLine("Elapsed Time: {0} ms", sw.ElapsedMilliseconds);
      Console.WriteLine("Done. Press any key...");
      Console.ReadKey();
    }

    private static void TimeObjectQuery()
    {
      var sw = new System.Diagnostics.Stopwatch();
      sw.Start();
      using (var context = new AWEntities())
      {
        var custList = context.AWCustomers.ToList();

      }
      sw.Stop();
      Console.WriteLine("Elapsed Time: {0} ms", sw.ElapsedMilliseconds);
      Console.WriteLine("Done. Press any key...");
      Console.ReadKey();
    }

    //edmgen:
    //     edmgen /mode:ViewGeneration /inssdl:f:\models\AWModel.ssdl /incsdl:f:\models\AWModel.csdl /inmsl:f:\models\AWModel.msl /p:"F:\LCTP3Work\Book Samples Second Edition\Chatper19Console\Chapter19Console.csproj"
    //     edmgen /mode:ViewGeneration /inssdl:f:\models\BAModel.ssdl /incsdl:f:\models\BAModel.csdl /inmsl:f:\models\BAModel.msl /p:"F:\LCTP3Work\Book Samples Second Edition\Chatper19Console\Chapter19Console.csproj"


    private static void PerfTests()
    {
      var econn = new EntityConnection("name=AWEntities");
      var dbConnString = econn.StoreConnection.ConnectionString;
      //Console.WriteLine(DataReaderTest(dbconn.ConnectionString));
      //Console.WriteLine(ObjectQueryTest());
      //Console.WriteLine(LinqToEntitiesTest());
      //Console.WriteLine(LinqToSqlTest());
      DataReaderTest(dbConnString);
      PerfTest(QueryType.L2E);
      PerfTest(QueryType.CompiledL2E);
      PerfTest(QueryType.EntityObject);
      PerfTest(QueryType.L2S);
      Console.WriteLine("Done. Press any key...");
      Console.ReadKey();
    }


    private static void DataReaderTest(string connstring)
    {
      decimal testresults = 0;
      var resultList = new List<decimal>();
      string cmdText = "select CustomerID, NameStyle, Title, FirstName," +
                       "MiddleName, LastName,Suffix,CompanyName, " +
                       "SalesPerson, EmailAddress,Phone,PasswordHash, " +
                       "PasswordSalt, rowguid, ModifiedDate " +
                       "FROM SalesLT.Customer";
      // start the timer
      var sw = new System.Diagnostics.Stopwatch();
      for (int i = 0; i < 2; i++)
      {
        // testresults.Clear();
        var sqlCon = new SqlConnection(connstring);
        sqlCon.Open();
        resultList.Clear();
        for (int j = 0; j < 101; j++)
        {

          sw.Reset();
          sw.Start();

          var cmd = new SqlCommand(cmdText, sqlCon);
          var reader = cmd.ExecuteReader();
          while (reader.Read())
          {
            var lastItem = reader[14];
            //var cust = new AWCustomer
            //                  {
            //                    CustomerID = (int)reader["CustomerID"],
            //                    NameStyle = (bool)reader["NameStyle"],
            //                    Title = (reader.IsDBNull(2) ? "" : (string)reader["Title"]),
            //                    FirstName = (string)reader["FirstName"],
            //                    MiddleName = (reader.IsDBNull(4) ? "" : (string)reader["MiddleName"]),
            //                    LastName = (string)reader["LastName"],
            //                    Suffix = (reader.IsDBNull(6) ? "" : (string)reader["Suffix"]),
            //                    CompanyName = (string)reader["CompanyName"],
            //                    SalesPerson = (string)reader["SalesPerson"],
            //                    EmailAddress = (string)reader["EmailAddress"],
            //                    Phone = (string)reader["Phone"],
            //                    PasswordHash = (string)reader["PasswordHash"],
            //                    PasswordSalt = (string)reader["PasswordSalt"],
            //                    rowguid = (Guid)reader["rowguid"],
            //                    ModifiedDate = (DateTime)reader["ModifiedDate"]
            //                  };
          }

          resultList.Add(sw.ElapsedMilliseconds);
          reader.Close();
          sw.Stop();
        }
        sqlCon.Close();
      }
      Console.WriteLine("DataReader query 1:{0}", resultList[0]);
      Console.WriteLine("DataReader query 2:{0}", resultList[1]);
      Console.WriteLine("DataReader query 3:{0}", resultList[2]);
      resultList.RemoveAt(0);
      Console.WriteLine("count: {0}", resultList.Count());
      Console.WriteLine("Total last 100 queries: {0}", resultList.Sum());
      Console.WriteLine("Avg last 100 queries: {0}", resultList.Average());
      Console.WriteLine();
    }

  
    private static string LinqToEntitiesTest()
    {
      var compQuery = CompiledQuery.Compile<AWEntities,
        IQueryable<AWCustomer>>((AWEntities ctx) =>
                              from cust in ctx.AWCustomers select cust);


      var resultList = new List<decimal>();
      decimal testresults = 0;
      var sw = new System.Diagnostics.Stopwatch();
      var sw2 = new System.Diagnostics.Stopwatch();

      for (int i = 0; i < 2; i++)
      {
        sw.Reset();
        sw.Start();

        resultList.Clear();
        var context = new AWEntities();  //<--been moving this in and out of the next for loop
        for (int j = 0; j < 100; j++)
        {
          //sw2.Reset();
          //sw2.Start();


          //------------using compiled query
          // var customers = compQuery.Invoke(context); 

          //iterating is about the same time as tolist
          var customers = (from c in context.AWCustomers select c).ToList();
          // sw2.Stop();
          //resultList.Add(sw2.ElapsedMilliseconds);
        }
        //Console.WriteLine("l2e query 1:{0}", resultList[0]);
        //        Console.WriteLine("l2e query 2:{0}", resultList[1]);
        //        Console.WriteLine("l2e query 3:{0}", resultList[2]);
        //        Console.WriteLine("total {0}", resultList.Sum());
        //        Console.ReadKey();

        sw.Stop();
        testresults = sw.ElapsedMilliseconds;

      }

      Console.WriteLine("LINQ to Entities: {0}ms", testresults);
      Console.ReadKey();
      return String.Format("LINQ to Entities: {0}ms", testresults);
    }


    private static string ObjectQueryTest()
    {
      var resultList = new List<decimal>();
      decimal testresults = 0;
      var sw = new System.Diagnostics.Stopwatch();
      var sw2 = new System.Diagnostics.Stopwatch();
      for (int i = 0; i < 2; i++)
      {
        //sw.Reset();
        //sw.Start();
        resultList.Clear();
        var context = new AWEntities();  //<--been moving this in and out of the next for loop
        for (int j = 0; j < 100; j++)
        {
          sw2.Reset();
          sw2.Start();


          //iterating is about the same time as tolist
          var customers = context.CreateQuery<Customer>("Customers").ToList();
          sw2.Stop();
          resultList.Add(sw2.ElapsedMilliseconds);
        }
        //sw.Stop();

        testresults = sw.ElapsedMilliseconds;
      }
      Console.WriteLine("obj query 1:{0}", resultList[0]);
      Console.WriteLine("obj query 2:{0}", resultList[1]);
      Console.WriteLine("obj query 3:{0}", resultList[2]);
      return String.Format("ObjectQuery: {0}ms", testresults);
    }

    private static void PerfTest(QueryType qType)
    {
      //var compQuery = CompiledQuery.Compile<AWEntities,
      //  IQueryable<Customer>>((AWEntities ctx) =>
      //                        from cust in ctx.Customers select cust);


      decimal testresults = 0;
      var sw = new System.Diagnostics.Stopwatch();
      var resultList = new List<decimal>();
      //do two loops for each query

      for (int i = 0; i < 2; i++)
      {
        //sw.Reset();
        //sw.Start();
        resultList = new List<decimal>();
        switch (qType)
        {
          case QueryType.L2E:
             ExecuteQueryLoop(new AWEntities(), null, resultList, QueryType.L2E,100);
            //ExecuteQueryLoop(null, null, resultList, QueryType.L2E, 100);
            break;
          case QueryType.EntityObject:
            ExecuteQueryLoop(new AWEntities(),null,resultList, QueryType.EntityObject,100);
            //ExecuteQueryLoop(null, null, resultList, QueryType.EntityObject, 100);
            break;
          case QueryType.L2S:
            ExecuteQueryLoop(null, new AWL2SDataContext(), resultList, QueryType.L2S, 100);
            break;
          case QueryType.CompiledL2E:
            ExecuteQueryLoop(new AWEntities(), null, resultList, QueryType.CompiledL2E, 100);
            break;
          case QueryType.DataReader:
            break;
          default:
            throw new ArgumentOutOfRangeException("qtype");
        }
        // sw.Stop();
        testresults = sw.ElapsedMilliseconds;
      }
      Console.WriteLine("{0} query 1:{1}", qType.ToString(), resultList[0]);
      Console.WriteLine("{0} query 2:{1}", qType.ToString(), resultList[1]);
      Console.WriteLine("{0} query 3:{1}", qType.ToString(), resultList[2]);
      Console.WriteLine("{0} query 4:{1}", qType.ToString(), resultList[3]);
      Console.WriteLine("{0} query 5:{1}", qType.ToString(), resultList[4]);
      Console.WriteLine("{0} query 6:{1}", qType.ToString(), resultList[5]);
      resultList.RemoveAt(0);
      Console.WriteLine("Total last 100 queries: {0}", resultList.Sum());
      Console.WriteLine("Avg last 100 queries: {0}", resultList.Average());
      Console.WriteLine();
    }

    private static void ExecuteQueryLoop(AWEntities oContext, AWL2SDataContext dContext, List<decimal> resultList, QueryType qType, int LoopCount)
    {
      var compQuery = CompiledQuery.Compile<AWEntities, IQueryable<AWCustomer>>
        ((AWEntities ctx ) =>
         from c in ctx.AWCustomers select c);


      for (int j = 0; j < LoopCount; j++)
      {
        var sw2 = new System.Diagnostics.Stopwatch();
        sw2.Start();
        //------------using compiled query
        // var customers = compQuery.Invoke(context); 

        //iterating is about the same time as tolist
        switch (qType)
        {
          case QueryType.L2E:
           // oContext = new AWEntities();
            oContext.AWCustomers.MergeOption = MergeOption.OverwriteChanges;
            var customers = (from c in oContext.AWCustomers select c).ToList();
            break;
          case QueryType.EntityObject:
          //  oContext = new AWEntities();
            oContext.AWCustomers.MergeOption = MergeOption.OverwriteChanges;
            var oqCusts = oContext.CreateQuery<AWCustomer>("AWCustomers").ToList();
            break;
          case QueryType.L2S:
            var l2SCusts = (from c in dContext.L2SCustomers select c).ToList();
            break;
          case QueryType.CompiledL2E:
            var compCusts = compQuery.Invoke(oContext).ToList();

            break;
          case QueryType.DataReader:
            break;
          default:
            throw new ArgumentOutOfRangeException("qType");
        }
        sw2.Stop();
        resultList.Add(sw2.ElapsedMilliseconds);
      }
    }

    private static string LinqToSqlTest()
    {
      //var compQuery = CompiledQuery.Compile<AWEntities,
      //  IQueryable<Customer>>((AWEntities ctx) =>
      //                        from cust in ctx.Customers select cust);


      var resultList = new List<decimal>();
      decimal testresults = 0;
      var sw = new System.Diagnostics.Stopwatch();
      var sw2 = new System.Diagnostics.Stopwatch();

      for (int i = 0; i < 2; i++)
      {
        //sw.Reset();
        //sw.Start();

        resultList.Clear();
        var context = new AWL2SDataContext();  //<--been moving this in and out of the next for loop
        for (int j = 0; j < 100; j++)
        {
          sw2.Reset();
          sw2.Start();


          //------------using compiled query
          // var customers = compQuery.Invoke(context); 

          //iterating is about the same time as tolist
          var customers = (from c in context.L2SCustomers select c).ToList();
          sw2.Stop();
          resultList.Add(sw2.ElapsedMilliseconds);
        }

        //sw.Stop();
        //testresults = sw.ElapsedMilliseconds;
      }

      Console.WriteLine("l2s query 1:{0}", resultList[0]);
      Console.WriteLine("l2s query 2:{0}", resultList[1]);
      Console.WriteLine("l2s query 3:{0}", resultList[2]);

      return String.Format("LINQ to SQL: {0}ms", testresults);
    }
  }

  internal enum QueryType
  {
    L2E = 1,
    EntityObject = 2,
    L2S = 3,
    DataReader = 4,
    CompiledL2E=5
  }
}
