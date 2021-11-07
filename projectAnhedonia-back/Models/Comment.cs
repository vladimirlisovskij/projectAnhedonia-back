using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace projectAnhedonia_back.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public long? AuthorId { get; set; }
        public string Content { get; set; }
        public long PostId { get; set; }
        public DateTime CreationDateTime { get; set; }

        [JsonIgnore]
        public virtual User Author { get; set; }
        [JsonIgnore]
        public virtual Post Post { get; set; }
    }
}
