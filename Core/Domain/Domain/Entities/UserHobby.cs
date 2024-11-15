using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserHobby
    {
        [Key]
        public int UserHobbyId { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public AppUser User { get; set; }

        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
    }
}