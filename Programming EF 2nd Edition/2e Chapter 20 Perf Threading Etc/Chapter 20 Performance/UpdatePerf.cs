using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data;


namespace Chapter20ConsolePerf
{
  class UpdatePerf
  {
    private static int iOuterLoop = 2;
    private static int iInnerloop = 100;
    private static string connectionString = "Data Source=127.0.0.1;Initial Catalog=AdventureWorksLT;Integrated Security=True";



    static void Main(string[] args)
    {

      // WarmUp(connectionString);
      Console.WriteLine("Average executing {0} times getting all customers {1} times", iOuterLoop, iInnerloop);
            Console.WriteLine();

            Console.WriteLine("DataAdapter UpdateBatch 100: {0}ms", DataAdapterBatchUpdateTest(connectionString));
            Console.WriteLine();
          
            Console.WriteLine("DataAdapter Update: {0}ms", DataAdapterUpdateTest(connectionString));
            Console.WriteLine();
              Console.WriteLine("Object Services Update: {0}ms", ObjectServicesUpdateTest());
            Console.WriteLine();
            Console.WriteLine("LINQ to SQL Update: {0}ms", LINQtoSQLUpdateTest());
      Console.WriteLine();
        
        Console.WriteLine("...");
      Console.ReadKey();
      clearnewcusts(connectionString);
    }

   
    private static decimal DataAdapterUpdateTest(string connstring)
    {
        List<decimal> testresults = new List<decimal>();
        string cmdText = "select CustomerID, NameStyle," +
                         "Title, FirstName, MiddleName, LastName, Suffix,CompanyName,SalesPerson,EmailAddress,Phone,PasswordHash, PasswordSalt, rowguid, ModifiedDate from SalesLT.Customer";

        // start the timer
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        SqlConnection sqlCon = new SqlConnection(connstring);
        for (int j = 0; j < iInnerloop; j++)
        {

            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(cmdText, sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DateTime modDate = (DateTime)dr["ModifiedDate"];
                dr["ModifiedDate"] = modDate.AddDays(1);
            }
            for (int iAdd = 0; iAdd < 10; iAdd++)
            {
              DataRow newDR = dt.NewRow();
              newDR["nameStyle"] = true;
              newDR["firstName"] = "new";
              newDR["lastname"] = "cust";
              newDR["passwordHash"] = "pw";
              newDR["passwordSalt"] = "salt";
              newDR["rowguid"] = Guid.NewGuid();
              newDR["modifiedDate"] = DateTime.Now;
              //newDR["inactive"] = false;
              dt.Rows.Add(newDR);
            }
            builder.GetUpdateCommand();
            builder.GetInsertCommand();
            sw.Reset();
            sw.Start();
            da.Update(dt);
            sqlCon.Close();
            sw.Stop();
            testresults.Add((decimal)sw.ElapsedMilliseconds);
            clearnewcusts(connectionString);

        }
        //toss first result, calc average of rest
        testresults.Remove(0);
        return testresults.Average();
    }

    private static decimal DataAdapterBatchUpdateTest(string connstring)
    {
        List<decimal> testresults = new List<decimal>();
        string cmdText = "select CustomerID, NameStyle," +
                         "Title, FirstName, MiddleName, LastName, Suffix,CompanyName,SalesPerson,EmailAddress,Phone,PasswordHash, PasswordSalt, rowguid, ModifiedDate from SalesLT.Customer";

        // start the timmer
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

       
            SqlConnection sqlCon = new SqlConnection(connstring);
            // sqlCon.Open();
            for (int j = 0; j < iInnerloop; j++)
            {

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(cmdText, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime modDate = (DateTime)dr["ModifiedDate"];
                    dr["ModifiedDate"] = modDate.AddDays(1);
                }
                for (int iAdd = 0; iAdd < 10; iAdd++)
                {
                  DataRow newDR = dt.NewRow();
                  newDR["nameStyle"] = true;
                  newDR["firstName"] = "new";
                  newDR["lastname"] = "cust";
                  newDR["passwordhash"] = "pw";
                  newDR["passwordSalt"] = "salt";
                  newDR["rowguid"] = Guid.NewGuid();
                  newDR["modifiedDate"] = DateTime.Now;
                  //  newDR["inactive"] = false;
                  dt.Rows.Add(newDR);
                }

                    builder.GetUpdateCommand();
                    builder.GetInsertCommand();
                    sw.Reset();
                    sw.Start();
                    da.UpdateBatchSize = 100;
                    da.Update(dt);
                    sqlCon.Close();
                    sw.Stop();

                 testresults.Add((decimal)sw.ElapsedMilliseconds);
                 clearnewcusts(connectionString);
            }
       
        // get the average time 
        //toss first result, calc average of rest
        clearnewcusts(connectionString);
        testresults.Remove(0);
        return testresults.Average();
    }
      
      private static decimal ObjectServicesUpdateTest()
    {
        List<decimal> testresults = new List<decimal>();
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            var context = new AWEntities();
            for (int j = 0; j < iInnerloop; j++)
            {
               
                var customers = from c in context.AWCustomers select c;
                foreach (AWCustomer cust in customers)
                {
                   AWCustomer c = cust;
                    c.ModifiedDate = c.ModifiedDate.AddDays(1);
                    
                }
                for (int iAdd = 0; iAdd < 10; iAdd++)
                {
                  AWCustomer cust = AWCustomer.CreateAWCustomer(0, true, "new", "cust", "pw", "salt", Guid.NewGuid(), DateTime.Now);
                  context.AWCustomers.AddObject(cust);
                }

                sw.Reset();
                sw.Start();
                context.SaveChanges();
                sw.Stop();
                testresults.Add((decimal)sw.ElapsedMilliseconds);
                clearnewcusts(connectionString);
            }

        // figure out how long this took
        //toss first result, calc average of rest
        clearnewcusts(connectionString);

          testresults.Remove(0);
        return testresults.Average();
    }
      private static decimal LINQtoSQLUpdateTest()
      {
        List<decimal> testresults = new List<decimal>();
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        var AWL2SContext = new AWL2SDataContext();
        for (int j = 0; j < iInnerloop; j++)
        {

          var customers = from c in AWL2SContext.L2SCustomers select c;
          foreach (L2SCustomer cust in customers)
          {
            L2SCustomer o = cust;
            o.ModifiedDate = o.ModifiedDate.AddDays(1);

          }
          for (int iAdd = 0; iAdd < 10; iAdd++)
          {
            L2SCustomer cust = new L2SCustomer();
            cust.NameStyle = true;
            cust.FirstName = "new";
            cust.LastName = "cust";
            cust.PasswordHash = "pw";
            cust.PasswordSalt = "salt";
            cust.rowguid = Guid.NewGuid();
            cust.ModifiedDate = DateTime.Now;

            AWL2SContext.L2SCustomers.InsertOnSubmit(cust);
          }

          sw.Reset();
          sw.Start();
          AWL2SContext.SubmitChanges();
          sw.Stop();
          testresults.Add((decimal)sw.ElapsedMilliseconds);
          clearnewcusts(connectionString);
        }

        // figure out how long this took
        //toss first result, calc average of rest
        clearnewcusts(connectionString);
        testresults.Remove(0);
        return testresults.Average();
      }

      private static void clearnewcusts(string connstring)
      { 
            using (SqlConnection sqlCon = new SqlConnection( connstring))
  {
                sqlCon.Open();
                string cmdText = "DELETE from salesLT.Customer where firstname='new' and lastname='cust'";

                SqlCommand cmd = new SqlCommand(cmdText, sqlCon);
          cmd.ExecuteNonQuery();
  }   }

  }
}

