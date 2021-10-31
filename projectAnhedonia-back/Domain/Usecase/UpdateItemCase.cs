using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Entity;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Domain.Usecase
{
    public class UpdateItemCase
    {
        private readonly IDataBaseRepository _repository;

        public UpdateItemCase(IDataBaseRepository repository)
        {
            _repository = repository;
        }
        
        public Task UpdateItem(TestItemDto data) => _repository.UpdateItem(data);
    }
}