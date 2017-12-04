using System;
using System.Diagnostics;
using System.IO;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using XForms.Data.DbConnnections;
using XForms.iOS.DbConnections;

[assembly: Dependency(typeof(SQLiteiOSConnection))]
namespace XForms.iOS.DbConnections
{
    public class SQLiteiOSConnection : ISQLiteConnection
    {
        private static string GetDatabasePath()
        {
            var sqliteFilename = "Testdb.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Documents");
            var path = Path.Combine(libraryPath, sqliteFilename);
            return path;
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var asyncConnection = new SQLiteAsyncConnection(HandleFunc);
            return asyncConnection;
        }

        public ISQLitePlatform SqliteConnection
        {
            get;
            set;
        }

        private SQLiteConnectionWithLock _conn;
        private SQLiteConnectionWithLock HandleFunc()
        {
            var dbPath = GetDatabasePath();
            Debug.WriteLine("Sqlite Connection Path: " + dbPath);
            var platform = new SQLitePlatformIOS();
            var connectionFactory = new Func<SQLiteConnectionWithLock>(
                () =>
                {
                    if (_conn == null)
                    {
                        _conn =
                        new SQLiteConnectionWithLock(platform,
                                new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: true));
                    }
                    return _conn;
                });
            return connectionFactory.Invoke();
        }
    }
}
