using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectAnhedonia_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly MainDatabaseContext _context;

        // Вот тут происходит magic - ASP.NET будет сам создавать объект MainDatabaseContext
        // и передавать его в конструктор каждый раз
        public TestController(MainDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        /// <summary>
        /// Инициализирует базу данных тестовыми значениями
        /// </summary>
        [HttpPost("Initialize")]
        public void Initialize()
        {
            var user1 = new User() { Username = "TestUser1", RegistrationDate = DateTime.Now, About = "Я просто милый юзверь №1" };
            var user2 = new User() { Username = "TestUser2", RegistrationDate = DateTime.Now, About = "Ещё один милый юзверь №2" };
            user1.SetPassword("12345");
            user2.SetPassword("12345");
            _context.Users.Add(user1);
            _context.Users.Add(user2);

            // Не забываем вызывать SaveChanges() - именно это завершает транзакцию в бд и сохраняет данные
            _context.SaveChanges();
            // Кроме того, SaveChanges позволяет нам получить ID новосозданной записи, если там был инкремент
            // Всё сразу запишется в объект

            var post = new Post() { AuthorId = user1.Id, Title = "Тестовый пост", Content = "Найс контент", CreationDateTime = DateTime.Now };
            _context.Posts.Add(post);

            // Так же вместо того, чтобы прописывать ID вручную, как я сделал в объекте выше (AuthorId = user1.Id),
            // Entity поддерживает присваивание виртуальным полям. Он разбёрется что к чему и мне это очень нравится ;)
            var coauthorRecord = new Coauthor() { Post = post, User = user2 };
            _context.Coauthors.Add(coauthorRecord);

            var comment = new Comment() { Author = user2, Post = post, Content = "Классный пост у нас вышел. Норм статья!" };
            _context.Comments.Add(comment);

            _context.SaveChanges();
        }

        /// <summary>
        /// Получить список всех пользователей.
        /// ЗАМЕТЬ! В реальности очень вряд ли нужно вкладывать в общий список пользователя информацию о
        /// всех его комментах и о всех его постах т.п., т.е. в реальности ненужные поля нужно закрывать
        /// при помощи [JsonIgnore], а сами закрытые поля отправлять в отдельном GET запросе специально 
        /// для этого.
        /// 
        /// Но для тестовых целей сейчас пойдёт)
        /// 
        /// (P.S. У всех остальных классов я закрыл при помощи [JsonIgnore])
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet("Users")]
        public User[] GetUserList()
        {
            var users = _context.Users
                .Include(u => u.CoauthorsRecords)
                .Include(u => u.Comments)
                .Include(u => u.Posts)
                .ToArray();

            return users;
        }


        /// <summary>
        /// Очищает базу данных. Это стоит удалить потом или ограничить доступ с фронта ;)
        /// Написано совсем неэффективно, но для теста сойдет
        /// </summary>
        [HttpDelete("EmptyDatabase")]
        public void EmptyDatabase()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.Posts.RemoveRange(_context.Posts);
            _context.Images.RemoveRange(_context.Images);
            _context.Coauthors.RemoveRange(_context.Coauthors);
            _context.Comments.RemoveRange(_context.Comments);

            _context.SaveChanges();
        }
    }
}
