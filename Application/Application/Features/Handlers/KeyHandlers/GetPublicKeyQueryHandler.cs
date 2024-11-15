using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.KeyQueries;
using Application.Features.Results.KeyResults;
using Application.Interfaces.UserKeyRep;
using MediatR;

namespace Application.Features.Handlers.KeyHandlers
{
    public class GetPublicKeyQueryHandler: IRequestHandler<GetUserPublicKeyQuery, GetPublicKeyResponse>
    {
        private readonly IUserKeyRepositry _userKeyRepository;

        public GetPublicKeyQueryHandler(IUserKeyRepositry userKeyRepository)
        {
            _userKeyRepository = userKeyRepository;
        }

        public async Task<GetPublicKeyResponse> Handle(GetUserPublicKeyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userKey = await _userKeyRepository.GetByUserIdAsync(request.userId);

                if (userKey == null)
                {
                    return null;
                }

                return new GetPublicKeyResponse
                {
                    UserId = userKey.UserId,
                    PublicKey = userKey.PublicKey
                };
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                throw new ApplicationException("Public key alınırken bir hata oluştu", ex);
            }
        }
    
    }
}