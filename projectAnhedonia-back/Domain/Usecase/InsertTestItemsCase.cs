using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Domain.Usecase
{
    public class InsertTestItemsCase
    {
        private readonly IDataBaseRepository _repository;

        public InsertTestItemsCase(IDataBaseRepository repository)
        {
            _repository = repository;
        }

        public Task InsertTestItem(TestItemDto data) => _repository.InsertTestItem(data);
    }
}