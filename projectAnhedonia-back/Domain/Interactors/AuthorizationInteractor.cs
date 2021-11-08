using System.Threading.Tasks;
using projectAnhedonia_back.Common;
using projectAnhedonia_back.Domain.Entities.Dto.User;
using projectAnhedonia_back.Domain.Repositories;

namespace projectAnhedonia_back.Domain.Interactors
{
    public class AuthorizationInteractor
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        private readonly IMainDbRepository _mainDbRepository;

        public AuthorizationInteractor(IAuthorizationRepository authorizationRepository,
            IMainDbRepository mainDbRepository)
        {
            _authorizationRepository = authorizationRepository;
            _mainDbRepository = mainDbRepository;
        }

        public Task<string> AuthorizeUserByCreds(UserCredsDto creds)
        {
            return _mainDbRepository
                .GetIdByCreds(creds)
                .MapResult(id => _authorizationRepository.CreateBearerForUser(id));
        }

        public long GetUserIdFromBearer(string bearer)
        {
            return _authorizationRepository.GetUserIdFromBearer(bearer);
        }
    }
}