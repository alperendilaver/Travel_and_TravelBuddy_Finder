using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.PostResults
{
    public class PostResult
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }
        public DateTime PostedTime { get; set; }
    }
}