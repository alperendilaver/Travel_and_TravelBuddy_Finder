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
    public class GetPrivateKeyQueryHandler : IRequestHandler<GetUserPrivateKeyQuery, GetPrivateKeyResponse>
    {
        private readonly IUserKeyRepositry _repositry;

        public GetPrivateKeyQueryHandler(IUserKeyRepositry repositry)
        {
           _repositry = repositry;
        }

        public async Task<GetPrivateKeyResponse> Handle(GetUserPrivateKeyQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositry.GetEncryptedPrivateKey(request.UserId);
            return new GetPrivateKeyResponse{EncryptedPrivateKey = entity.privateKey,UserId = request.UserId,iv = entity.iv};
        }
    }
}