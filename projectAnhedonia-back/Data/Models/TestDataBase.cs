using System.Collections.Generic;
using System.Threading.Tasks;
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

        private DbSet<TestItemDbDto> TodoItems { get; set; }

        public Task<List<TestItemDbDto>> GetAllTestItems()
        {
            return TodoItems.ToListAsync();
        }

        public Task<TestItemDbDto> GetItemById(long id)
        {
            return TodoItems.SingleAsync(item => item.Id == id);
        }

        public Task<int> InsertTestItem(TestItemDbDto item)
        {
            TodoItems.Add(item);
            return SaveChangesAsync();
        }

        public Task<int> DeleteById(long id)
        {
            var item = new TestItemDbDto {Id = id};
            TodoItems.Remove(item);
            return SaveChangesAsync();
        }

        public Task<int> UpdateTestItem(TestItemDbDto item)
        {
            TodoItems.Update(item);
            return SaveChangesAsync();
        }
    }
}