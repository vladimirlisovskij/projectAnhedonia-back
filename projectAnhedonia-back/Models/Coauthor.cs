using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace projectAnhedonia_back.Models
{
    public partial class Coauthor
    {
        public long PostId { get; set; }
        public long UserId { get; set; }

        [JsonIgnore]
        public virtual Post Post { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
