using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.MatchCommands;
using Application.Features.Commands.NotificationCommands;
using Application.Features.Commands.SuggestedUserCommands;
using Application.Features.Results.General;
using Application.Interfaces.MatchRep;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Handlers.MatchHandlers
{
    public class LikeUserCommandHandler : IRequestHandler<LikeUserCommand, GeneralResponse>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        public LikeUserCommandHandler(IMatchRepository matchRepository, IMediator mediator, UserManager<AppUser> userManager)
        {
            _matchRepository = matchRepository;
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<GeneralResponse> Handle(LikeUserCommand request, CancellationToken cancellationToken)
        {

            var response = new GeneralResponse();
            //beğenme kaydı kontrolu
            var existingMatch = await _matchRepository.CheckMatch(request.LikerId, request.LikeeId);
            if (existingMatch == null)
            {
                // yeni beğenme kaydı oluşturma
                var newMatch = new Match
                {
                    LikeeId = request.LikeeId,
                    LikerId = request.LikerId,
                    IsLiked = true,
                    IsMatched = false,
                    TravelDestinaitonId = 1
                };
                response.IsSucceded = true ? await _matchRepository.AddMatch(newMatch) > 0 : false;
                existingMatch = newMatch;

                var resp = await _mediator.Send(new RemoveSuggestedUserCommand(request.SuggestId));
                if (resp.IsSucceded)
                    response.Message += " Öneri kaldırıldı";
                if (response.IsSucceded == false)
                {
                    response.Message = "Beğeni Oluşturulamadı";
                    return response;
                }
            }
            else
            {
                // Zaten varsa sadece beğenme durumunu güncelle
                existingMatch.IsLiked = true;
                response.Message = "Zaten beğeni mevcut";
            }
            // Karşı tarafın bu kullanıcıyı beğenip beğenmediğini kontrol et
            var reciprocalMatch = await _matchRepository.CheckReciprocalMatch(request.LikerId, request.LikeeId);
            if (reciprocalMatch != null)
            {
                //await _mediator.Send(new CreateMatchCommand { FirstUserId = request.LikerId, SecondUserId = request.LikeeId });
                var user1 = await _userManager.FindByIdAsync(request.LikerId);
                var user2 = await _userManager.FindByIdAsync(request.LikeeId);
                await _mediator.Send(new MatchNotificationCommand(user1.Email, $"{user2.UserName} kullanıcısı ile eşleştiniz sohbete başlayın", "EŞLEŞMENİZ VAR"
                , user1.Id));
                await _mediator.Send(new MatchNotificationCommand(user2.Email, $"{user1.UserName} kullanıcısı ile eşleştiniz sohbete başlayın", "EŞLEŞMENİZ VAR"
                , user2.Id));

                response.IsSucceded = true ? await _matchRepository.UpdateMatches(existingMatch, reciprocalMatch) > 0 : false;
                response.Message += "\nEşleşme Gerçekleşti";
            }
            return response;
        }

    }
}