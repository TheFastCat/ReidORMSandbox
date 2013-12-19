using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication.Data.Model
{
    public class Customer
    {
        public Customer()
        { }

        public Customer(dynamic model)
        {
            Name = model.Name;
            Number = model.Number;
            URL = model.URL;
            Email = model.EMail; 
        }

        // TODO extend to hold the information needed for a Customer
        public string Name {get;set;}
        public int Number { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
    }
}
