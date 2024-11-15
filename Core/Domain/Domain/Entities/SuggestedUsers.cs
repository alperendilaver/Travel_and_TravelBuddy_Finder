using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SuggestedUsers
    {
        public int SuggestId { get; set; }
        public string RequestingUserId { get; set; }
        [ForeignKey("RequestingUserId")]
        public AppUser RequestingUser { get; set; }

        public string SuggestedUserId { get; set; }
        [ForeignKey("SuggestedUserId")]
        public AppUser SuggestedUser { get; set; }

    }
}