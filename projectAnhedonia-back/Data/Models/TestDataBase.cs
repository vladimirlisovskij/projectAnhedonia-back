using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Entity;

namespace projectAnhedonia_back.Data.Models
{
    public class TestDataBaseContext : DbContext
    {
        public TestDataBaseContext(DbContextOptions<TestDataBaseContext> options)
            : base(options)
        {
            
        }

        public DbSet<TestItemDbDto> TodoItems { get; set; }
    }
}