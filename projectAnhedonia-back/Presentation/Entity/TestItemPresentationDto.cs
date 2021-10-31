using projectAnhedonia_back.Domain.Entity;

namespace projectAnhedonia_back.Presentation.Entity
{
    public class TestItem
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public bool IsComplete { get; init; }
    };

    public static class TestItemPresentationMapper
    {
        public static TestItemDto ConvertToDomainLayer(this TestItem data)
        {
            return new TestItemDto(data.Id, data.Name, data.IsComplete);
        }

        public static TestItem ConvertToDataLayer(this TestItemDto data)
        {
            var res = new TestItem
            {
                Id = data.Id,
                Name = data.Name,
                IsComplete = data.IsComplete
            };
            return res;
        }
    }
}