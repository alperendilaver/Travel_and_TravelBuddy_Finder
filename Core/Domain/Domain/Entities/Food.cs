using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
    }
}