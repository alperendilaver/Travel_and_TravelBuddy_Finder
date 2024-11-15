using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Context { get; set; }
        public List<Post> Posts { get; set; }

    }
}