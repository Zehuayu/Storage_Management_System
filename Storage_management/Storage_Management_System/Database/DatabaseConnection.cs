using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Storage_Management_System.Database
{
    class DatabaseConnection
    {
        public readonly static string DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "LoginData.db");
        public readonly static string DbPathone = Path.Combine(ApplicationData.Current.LocalFolder.Path, "GooddsInfo.db");



        public static SQLiteConnection GetDbConnection()
        {
            // connect to SQLite, create a new database when the database is not exist.
            var conn = new SQLiteConnection(new SQLitePlatformWinRT(), DbPath);
            conn.CreateTable<LoginData>();
            return conn;
        }

        public static SQLiteConnection GetDbConnectionone()
        {
            var connone = new SQLiteConnection(new SQLitePlatformWinRT(), DbPathone);
            connone.CreateTable<GoodsInfo>();
            return connone;
        }

    }
}
