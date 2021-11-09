#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto.Database
{
    public sealed class Coauthor
    {
        public long PostId { get; set; }
        public long UserId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
