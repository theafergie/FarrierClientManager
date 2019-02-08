using FarrierClientManager.iOS.Persistence;
using FarrierClientManager.Persistence;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace FarrierClientManager.iOS.Persistence
{
        public class SQLiteDb : ISQLiteDb
        {
            public SQLiteAsyncConnection GetConnection()
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var path = Path.Combine(documentsPath, "MySQLite.FarrierClientManager");

                return new SQLiteAsyncConnection(path);
            }
        }
}