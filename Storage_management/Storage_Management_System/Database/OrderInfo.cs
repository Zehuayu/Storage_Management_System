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
        [Table("Order")]
        class Order
        {

            [PrimaryKey]

            [AutoIncrement]

            public int Id { get; set; }

            public string OrderGoods { get; set; }

            public string address { get; set; }

            public int Phonenumbe { get; set; }

            public string Price { get; set; }

            public string State { get; set; }

        }

    }
}
