using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public string LikerId { get; set; }
        [ForeignKey("LikerId")]
        public AppUser Liker { get; set; }
        public string LikeeId { get; set; }
        [ForeignKey("LikeeId ")]
        public AppUser Likee { get; set; }
        public bool IsLiked { get; set; } // Beğenme durumu (True = beğendi, False = beğenmedi)

        // Eşleşme olup olmadığını tutmak için
        public bool IsMatched { get; set; } // İki taraf da birbirini beğenirse True olur

        public int TravelDestinaitonId { get; set; }
        public TravelDestination Destination { get; set; }
    }
}