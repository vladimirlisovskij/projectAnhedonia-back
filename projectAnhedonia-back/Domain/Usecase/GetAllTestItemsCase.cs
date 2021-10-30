using System.Collections.Generic;
using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Domain.Usecase
{
    public class GetAllTestItemsCase
    {
        private readonly IDataBaseRepository _repository;

        public GetAllTestItemsCase(IDataBaseRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TestItemDto>> GetAllTestItems() => _repository.GetAllTestItems();
    }
}