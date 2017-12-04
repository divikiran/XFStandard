using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using XForms.Data.Entities;

namespace XForms.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        //Get Connection
        SQLiteAsyncConnection ConnectionAsync { get; set; }

        //Object level operations
        Task<int> InsertAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);
        Task<T> GetByIdAsync(T Item);
        Task<T> GetByIdAsync(int Id);
        Task<int> InsertOrUpdateAsync(T Item);

        //Collection level operations
        Task<int> InsertAllAsync(List<T> items);
        Task<int> UpdateAllAsync(List<T> items);
        Task<int> DeleteAllAsync();
        Task<List<T>> GetAllAsync();
        Task<int> InsertOrReplaceAllAsync(List<T> items);

        //Get count
        Task<int> GetTableRowsCountAsync();
    }
}
