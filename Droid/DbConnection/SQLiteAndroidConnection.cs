using System;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using XForms.Data.DbConnnections;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using test.Droid.DbConnection;

[assembly: Dependency(typeof(SQLiteAndroidConnection))]
namespace test.Droid.DbConnection
{
    public class SQLiteAndroidConnection : ISQLiteConnection
    {
        public SQLiteAndroidConnection()
        {
        }

        private static string GetDatabasePath()
        {
            const string sqliteFilename = "Testdb.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
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
            var platform = new SQLitePlatformAndroid();
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
