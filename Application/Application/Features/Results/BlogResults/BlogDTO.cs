using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.PostResults;

namespace Application.Features.Results.BlogResults
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Context { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}