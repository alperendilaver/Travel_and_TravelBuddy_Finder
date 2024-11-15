using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Context { get; set; }
        public DateTime PostedTime { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blog { get; set; }
    }
}