using System;
using System.IO;
using FarrierClientManager.Droid.Persistence;
using FarrierClientManager.Persistence;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace FarrierClientManager.Droid.Persistence
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