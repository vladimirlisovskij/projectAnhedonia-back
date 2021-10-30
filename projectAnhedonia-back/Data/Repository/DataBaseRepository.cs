using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entity;
using projectAnhedonia_back.Data.Models;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Data.Repository
{
    public class DataBaseRepository : IDataBaseRepository
    {
        private readonly TestDataBaseContext _dataBase;

        public DataBaseRepository(TestDataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public Task<IEnumerable<TestItemDto>> GetAllTestItems()
        {
            var a = _dataBase.TodoItems.ToListAsync();
            return _dataBase.TodoItems.ToListAsync().ContinueWith(
                task => task.Result.Select(item => new TestItemDto(item.Id, item.Name, item.IsComplete))
            );
        }

        public Task InsertTestItem(TestItemDto data)
        {
            var newRow = new TestItemDbDto();
            newRow.Name = data.Name;
            newRow.IsComplete = data.IsComplete;
            _dataBase.TodoItems.Add(newRow);
            return _dataBase.SaveChangesAsync();
        }
    }
}