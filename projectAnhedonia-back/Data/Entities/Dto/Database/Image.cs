using System.Collections.Generic;

#nullable disable

namespace projectAnhedonia_back.Data.Entities.Dto.Database
{
    public sealed class Image
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }

        public ICollection<Post> Posts { get; set; }
        
        public Image()
        {
            Posts = new HashSet<Post>();
        }
    }
}
