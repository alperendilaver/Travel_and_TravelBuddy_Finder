using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.General;
using MediatR;

namespace Application.Features.Commands.MatchCommands
{
    public class LikeUserCommand : IRequest<GeneralResponse>
    {
        public int SuggestId { get; set; }  //suggestId
        public string LikerId { get; set; } // Beğenen kullanıcı
        public string LikeeId { get; set; } // Beğenilen kullanıcı

        public LikeUserCommand(string likerId, string likeeId, int suggestId)
        {
            LikerId = likerId;
            LikeeId = likeeId;
            SuggestId = suggestId;
        }
    }
}