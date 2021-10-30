using System.Threading.Tasks;
using System.Collections.Generic;
using projectAnhedonia_back.Data.Entity;
using projectAnhedonia_back.Domain.Entity;

namespace projectAnhedonia_back.Domain.Repository
{
    public interface IDataBaseRepository
    {
        public Task<IEnumerable<TestItemDto>> GetAllTestItems();

        public Task InsertTestItem(TestItemDto data);
    }
}