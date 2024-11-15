using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.SuggestedUserResults;

namespace Application.Interfaces.SuggestedUserRep
{
    public interface ISuggestedUserRepository
    {
        public Task<List<SuggestedUsersResult>> GetSuggestedUsersAsync(string userId);
    }
}