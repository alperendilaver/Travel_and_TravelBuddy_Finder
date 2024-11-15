using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.UserResults;

namespace Application.Features.Results.PostResults
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string postedTime { get; set; }
        public string Context { get; set; }
        public string UserId { get; set; }
        public UserDTO User { get; set; }
    }
}