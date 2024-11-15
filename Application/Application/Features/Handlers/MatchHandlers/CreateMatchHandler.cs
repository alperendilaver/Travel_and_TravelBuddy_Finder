// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Application.Features.Commands.MatchCommands;
// using Application.Features.Commands.NotificationCommands;
// using Application.Features.Results.General;
// using Application.Interfaces.IGeneralRepository;
// using Application.Interfaces.UserRepository;
// using Domain.Entities;
// using MediatR;
// using Microsoft.AspNetCore.Identity;

// namespace Application.Features.Handlers.MatchHandlers
// {
//     public class CreateMatchHandler : IRequestHandler<CreateMatchCommand, GeneralResponse>
//     {
//         private readonly IRepository<Match> _repository;
//         private readonly UserManager<AppUser> _userManager;
//         private readonly IMediator _mediator;
//         public CreateMatchHandler(IRepository<Match> repository, IMediator mediator, UserManager<AppUser> userRepository)
//         {
//             _repository = repository;
//             _mediator = mediator;
//             _userManager = userRepository;
//         }

//         public async Task<GeneralResponse> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {

//                 var user1 = await _userManager.FindByIdAsync(request.FirstUserId);
//                 var user2 = await _userManager.FindByIdAsync(request.SecondUserId);
//                 await _mediator.Send(new MatchNotificationCommand(user1.Email, $"{user2.UserName} kullanıcısı ile eşleştiniz sohbete başlayın", "EŞLEŞMENİZ VAR"
//                 , user1.Id));
//                 await _mediator.Send(new MatchNotificationCommand(user2.Email, $"{user1.UserName} kullanıcısı ile eşleştiniz sohbete başlayın", "EŞLEŞMENİZ VAR"
//                 , user2.Id));

//                 return new GeneralResponse
//                 {
//                     IsSucceded = true,
//                     Message = " başarılı şekilde oluşturuldu"
//                 };
//             }
//             catch (System.Exception ex)
//             {
//                 return new GeneralResponse { IsSucceded = false, Message = ex.Message };
//             }
//         }


//     }

// }