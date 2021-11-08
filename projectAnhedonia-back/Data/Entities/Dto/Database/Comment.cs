using System;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto
{
    public sealed class Comment
    {
        public long Id { get; set; }
        public long? AuthorId { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public DateTime CreationDateTime { get; set; }
        
        public User Author { get; set; }
        public Post Article { get; set; }
    }
}
