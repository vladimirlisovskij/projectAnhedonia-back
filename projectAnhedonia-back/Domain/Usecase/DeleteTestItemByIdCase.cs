using System.Threading.Tasks;
using projectAnhedonia_back.Domain.Repository;

namespace projectAnhedonia_back.Domain.Usecase
{
    public class DeleteTestItemByIdCase
    {
        private readonly IDataBaseRepository _repository;

        public DeleteTestItemByIdCase(IDataBaseRepository repository)
        {
            _repository = repository;
        }
        
        public Task DeleteItemById(long id) => _repository.DeleteItemById(id);
    }
}