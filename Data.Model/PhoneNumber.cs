using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication.Data.Model
{
    public class PhoneNumber
    {
        public int TableKey { get; set; }
        public int Number { get; set; }
        public string Code { get; set; }
        public string PNumber { get; set; }
    }
}
