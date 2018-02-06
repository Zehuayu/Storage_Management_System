using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage_Management_System.Database
{
    [Table("LoginData")]
    class LoginData
    {

        [PrimaryKey]

        [AutoIncrement]

        public int Id { get; set; }

        public String Password { get; set; }

    }
}
