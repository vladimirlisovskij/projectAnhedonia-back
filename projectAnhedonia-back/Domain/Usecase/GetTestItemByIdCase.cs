using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Domain.Usecase
{
    public class GetTestItemByIdCase
    {
        private readonly IDataBaseRepository _repository;

        public GetTestItemByIdCase(IDataBaseRepository repository)
        {
            _repository = repository;
        }

        public Task<TestItemDto> GetItemById(long id) => _repository.GetItemById(id);
    }
}