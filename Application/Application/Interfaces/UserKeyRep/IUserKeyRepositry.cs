using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.UserKeyRep
{
    public interface IUserKeyRepositry
    {
         Task<UserKey> GetByUserIdAsync(string userId);
         Task<KeyDTO> GetEncryptedPrivateKey(string userId);
    Task<bool> SaveKeyAsync(string userId, string publicKey,string EncryptedPrivateKey,string iv);
    Task<bool> UpdatePublicKeyAsync(string userId, string publicKey);
    Task<bool> DeactivateKeyAsync(string userId);
    }
}