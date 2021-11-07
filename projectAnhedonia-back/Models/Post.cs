using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace projectAnhedonia_back.Models
{
    public partial class Post
    {
        public Post()
        {
            Coauthors = new HashSet<Coauthor>();
            Comments = new HashSet<Comment>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public long? AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public long? PreviewImageId { get; set; }

        [JsonIgnore]
        public virtual User Author { get; set; }
        [JsonIgnore]
        public virtual Image PreviewImage { get; set; }
        [JsonIgnore]
        public virtual ICollection<Coauthor> Coauthors { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
