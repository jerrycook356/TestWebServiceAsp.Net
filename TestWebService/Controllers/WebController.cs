using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json;
using TestWebService.Models;
using System.Web.Script.Services;
using System.Text;

namespace TestWebService.Controllers
{
    public class WebController : ApiController
    {
        [HttpGet]
       
        public HttpResponseMessage Get()
        {
            Transaction trans;
             List<Transaction> transactions = new List<Transaction>();
              string queryString = "SELECT * FROM [Material Transaction]";
              OleDbConnection con;
              using (con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; " +
                  "Data Source = C:\\Users\\jerry\\source\\repos\\TestWebService\\TestWebService\\weigh.mdb"))
              {
                  try
                  {
                      OleDbCommand command = new OleDbCommand(queryString, con);
                      con.Open();
                      OleDbDataReader reader = command.ExecuteReader();
                      while (reader.Read())
                      {
                         trans = new Transaction();              
                         trans.SetTruckId(reader[1].ToString());
                         trans.SetSource(reader[3].ToString());
                         trans.SetDestination(reader[4].ToString());
                         trans.SetCustomer (reader[7].ToString()) ;
                        transactions.Add(trans);                                        
                      }
                  }catch(Exception e)
                  {
                      Debug.WriteLine(e.ToString());
                  }
              }
            Debug.WriteLine("size of transactions is = " + transactions.Count);
            var json = JsonConvert.SerializeObject(transactions);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);         
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
