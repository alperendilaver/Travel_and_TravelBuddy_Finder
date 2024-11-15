using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public List<UserHobby> UserHobbies { get; set; } // Kullanıcılar ile ilişki
    }
}