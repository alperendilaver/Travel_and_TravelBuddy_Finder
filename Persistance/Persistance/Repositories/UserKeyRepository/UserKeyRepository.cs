using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.UserKeyRep;
using Application.DTOs;
namespace Persistance.Repositories.UserKeyRepository
{
    public class UserKeyRepository : IUserKeyRepositry
    {
         private readonly JourneyCloudContext _context;

    public UserKeyRepository(JourneyCloudContext context)
    {
        _context = context;
    }

    public async Task<UserKey> GetByUserIdAsync(string userId)
    {
        return await _context.UserKeys
            .Where(x => x.UserId == userId && x.IsActive)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> SaveKeyAsync(string userId, string publicKey, string secretKey,string iv)
    {
        var existingKey = await GetByUserIdAsync(userId);
        if (existingKey != null)
        {
            return false; // Zaten aktif bir key var
        }

        var userKey = new UserKey
        {
            UserId = userId,
            PublicKey = publicKey,
            EncryptedPrivateKey = secretKey,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            iv = iv
        };

        _context.UserKeys.Add(userKey);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdatePublicKeyAsync(string userId, string publicKey)
    {
        var existingKey = await GetByUserIdAsync(userId);
        if (existingKey == null)
        {
            return false;
        }

        existingKey.PublicKey = publicKey;
        existingKey.UpdatedAt = DateTime.UtcNow;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeactivateKeyAsync(string userId)
    {
        var existingKey = await GetByUserIdAsync(userId);
        if (existingKey == null)
        {
            return false;
        }

        existingKey.IsActive = false;
        existingKey.UpdatedAt = DateTime.UtcNow;

        return await _context.SaveChangesAsync() > 0;
    }

        public async Task<KeyDTO> GetEncryptedPrivateKey(string userId)
        {
            var entity = await _context.UserKeys.Where(x=>x.UserId == userId).Select(x=> new { x.EncryptedPrivateKey, x.iv }).FirstOrDefaultAsync();
            return new KeyDTO{iv = entity.iv,privateKey = entity.EncryptedPrivateKey};
        }
    }
}