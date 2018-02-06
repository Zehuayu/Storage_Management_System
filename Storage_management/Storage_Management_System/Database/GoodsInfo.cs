using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Storage_Management_System.Database
{
    [Table("Goods")]
    class GoodsInfo
    {

        [PrimaryKey]

        [AutoIncrement]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Amount { get; set; }

        public string Price { get; set; }

        public string Supplier { get; set; }

    }
}
