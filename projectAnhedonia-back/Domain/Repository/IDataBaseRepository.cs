using System.Collections.Generic;
using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entity;

namespace projectAnhedonia_back.Domain.Repository
{
    public interface IDataBaseRepository
    {
        public Task<List<TestItemDto>> GetAllTestItems();

        public Task<TestItemDto> GetItemById(long id);

        public Task InsertTestItem(TestItemDto data);
        public Task DeleteItemById(long id);
        public Task UpdateItem(TestItemDto data);
    }
}