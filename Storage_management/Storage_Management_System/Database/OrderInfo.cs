using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Management_System.Database
{


    
    class OrderInfo
    {





        public string Id { get; set; }


        public string OrderGoods { get; set; }

        public string address { get; set; }

        public string phonenumber { get; set; }

        public bool status { get; set; }

        
    }
}
