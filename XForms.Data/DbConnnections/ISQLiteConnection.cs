using System;
using SQLite.Net.Async;

namespace XForms.Data.DbConnnections
{
    public interface ISQLiteConnection
    {
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
