using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entities.Dto;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext 
    {
        public virtual DbSet<Coauthor> Coauthors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}