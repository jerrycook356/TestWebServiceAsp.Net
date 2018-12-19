using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebService.Models
{
    public class Transaction
    {
        public Transaction()
        {

        }
        public string truckId;
        public string source;
        public string destination;
        public string customer;


        public void SetTruckId(string truckId)
        {
            this.truckId = truckId;
        }
        public string GetTruckId()
        {
            return truckId;
        }
        public void SetSource(string source)
        {
            this.source = source;
        }
        public string GetSource()
        {
            return source;
        }
        public void SetDestination(string destination)
        {
            this.destination = destination;
        }
        public string GetDestination()
        {
            return destination;
        }
        public void SetCustomer(string customer)
        {
            this.customer = customer;
        }
        public string GetCustomer()
        {
            return customer;
        }
    }
}