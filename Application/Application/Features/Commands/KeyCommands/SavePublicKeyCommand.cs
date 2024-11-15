using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.KeyResults;
using MediatR;

namespace Application.Features.Commands.KeyCommands
{
    public class SaveKeysCommand: IRequest<SavePublicKeyResponse>
    {
         public string UserId { get; set; }
        public string PublicKey { get; set; }
        public string EncryptedPrivateKey { get; set; }
        public string iv { get; set; }
        public SaveKeysCommand(string userId, string publicKey, string encryptedPrivateKey, string iv)
        {
            UserId = userId;
            PublicKey = publicKey;
            EncryptedPrivateKey = encryptedPrivateKey;
            this.iv = iv;
        }
    }
}