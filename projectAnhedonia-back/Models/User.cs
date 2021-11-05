using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace projectAnhedonia_back.Models
{
    public partial class User
    {
        public User()
        {
            CoauthorsRecords = new HashSet<Coauthor>();
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public string About { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Coauthor> CoauthorsRecords { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        /// <summary>
        /// Хеширует пароль и запрасывает в поле Password
        /// </summary>
        /// <param name="password">Пароль, который нужно захешировать</param>
        public void SetPassword(string password)
        {
            Password = sha256_hash(password);
        }

        // Стыбзил с https://stackoverflow.com/questions/16999361/obtain-sha-256-string-of-a-string
        private static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
