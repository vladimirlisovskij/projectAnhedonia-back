using System;
using System.Collections.Generic;

#nullable disable

namespace projectAnhedonia_back.Models
{
    public partial class Image
    {
        public Image()
        {
            Posts = new HashSet<Post>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
