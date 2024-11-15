using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.KeyResults
{
    public class GetPrivateKeyResponse
    {
        public string UserId { get; set; }
        public string EncryptedPrivateKey { get; set; }
        public string iv { get; set; }
    }
}