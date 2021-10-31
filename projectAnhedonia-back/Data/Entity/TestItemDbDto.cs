using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using projectAnhedonia_back.Domain.Entity;

namespace projectAnhedonia_back.Data.Entity
{
    public class TestItemDbDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public static class TestItemDbMapper
    {
        public static TestItemDto ConvertToDomainLayer(this TestItemDbDto data)
        {
            return new TestItemDto(data.Id, data.Name, data.IsComplete);
        }

        public static TestItemDbDto ConvertToDataLayer(this TestItemDto data)
        {
            var res = new TestItemDbDto
            {
                Name = data.Name,
                IsComplete = data.IsComplete
            };

            if (data.Id != 0) res.Id = data.Id;
            
            return res;
        }
    }
}