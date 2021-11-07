using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entities.Dto;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext
    {
        public Task<int> AddUser(User user)
        {
            Users.Add(user);
            return SaveChangesAsync();
        }

        public Task<int> RemoveUserById(long id)
        {
            Users.Remove(new User {Id = id});
            return SaveChangesAsync();
        }

        public Task<List<UserProfile>> GetAllUsers()
        {
            return Users
                .Select(u => new UserProfile
                {
                    Username = u.Username,
                    About = u.About,
                    RegistrationDate = u.RegistrationDate,
                    Articles = u.Posts.Select(a => a.Id)
                })
                .ToListAsync();
        }

        // TODO change username to token or something else that we get after registration complete
        public Task<long> GetIdByUsername(string username)
        {
            return Users
                .Where(u => u.Username == username)
                .Select(u => u.Id)
                .FirstAsync();
        }

        public Task<UserProfile> GetUserById(long id)
        {
            return Users
                .Where(u => u.Id == id)
                .Select(u => new UserProfile
                {
                    Username = u.Username,
                    About = u.About,
                    RegistrationDate = u.RegistrationDate,
                    Articles = u.Posts.Select(a => a.Id)
                })
                .FirstAsync();
        }
    }
}