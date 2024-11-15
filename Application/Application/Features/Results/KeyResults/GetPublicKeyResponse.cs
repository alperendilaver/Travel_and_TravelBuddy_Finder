using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.KeyResults
{
    public class GetPublicKeyResponse
    {
        public string UserId { get; set; }
        public string PublicKey { get; set; }
    }
}