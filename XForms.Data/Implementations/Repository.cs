using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite.Net.Async;
using Xamarin.Forms;
using XForms.Data.DbConnnections;
using XForms.Data.Entities;
using XForms.Data.Interfaces;

namespace XForms.Data.Implementations
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {

        public SQLiteAsyncConnection ConnectionAsync { get; set; }
        public Repository()
        {
            try
            {
                if (this.ConnectionAsync == null)
                {
                    var connection = DependencyService.Get<ISQLiteConnection>();
                    ConnectionAsync = connection.GetConnectionAsync();
                }
                ConnectionAsync.CreateTableAsync<T>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository Error: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(T item)
        {
            try
            {
                if (item != null)
                {
                    return await ConnectionAsync.DeleteAsync(item);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository Delete: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> DeleteAllAsync()
        {
            try
            {
                return await ConnectionAsync.DeleteAllAsync<T>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository DeleteAll: " + ex.Message);
                throw ex;
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await ConnectionAsync.Table<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository GetAll: " + ex.Message);
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(T Item)
        {
            try
            {
                return await ConnectionAsync.GetAsync<T>(Item.Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository GetById: " + ex.Message);
                throw ex;
            }
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            try
            {
                return await ConnectionAsync.GetAsync<T>(Id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository GetById: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> GetTableRowsCountAsync()
        {
            try
            {
                return await ConnectionAsync.Table<T>().CountAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository GetTableRowsCount: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertAsync(T item)
        {
            try
            {
                if (item != null)
                {
                    return await ConnectionAsync.InsertAsync(item);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository Insert: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertAllAsync(List<T> items)
        {
            try
            {
                if (items?.Count > 0)
                {
                    return await ConnectionAsync.InsertAllAsync(items);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository InsertAll: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertOrReplaceAllAsync(List<T> items)
        {
            try
            {
                if (items != null)
                {
                    return await ConnectionAsync.InsertOrReplaceAllAsync(items);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository InsertOrReplaceAll: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertOrUpdateAsync(T Item)
        {
            try
            {
                if (Item != null)
                {
                    return await ConnectionAsync.InsertOrReplaceAsync(Item);
                }
                return 1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository InsertOrUpdate: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(T item)
        {
            try
            {
                if (item != null)
                {
                    return await ConnectionAsync.UpdateAsync(item);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository Update: " + ex.Message);
                throw ex;
            }
        }

        public async Task<int> UpdateAllAsync(List<T> items)
        {
            try
            {
                if (items?.Count > 0)
                {
                    return await ConnectionAsync.UpdateAllAsync(items);
                }
                return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Repository UpdateAll: " + ex.Message);
                throw ex;
            }
        }
    }
}
