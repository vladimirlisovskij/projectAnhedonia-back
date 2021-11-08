#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto
{
    public sealed class Coauthor
    {
        public long PostId { get; set; }
        public long UserId { get; set; }

        public Post Article { get; set; }
        public User User { get; set; }
    }
}
