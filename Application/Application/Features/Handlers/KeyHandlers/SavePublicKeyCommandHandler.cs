using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands.KeyCommands;
using Application.Features.Results.KeyResults;
using Application.Interfaces.UserKeyRep;
using MediatR;

namespace Application.Features.Handlers.KeyHandlers
{
    public class SavePublicKeyCommandHandler : IRequestHandler<SaveKeysCommand, SavePublicKeyResponse>
    {
        private readonly IUserKeyRepositry _userKeyRepository;
    
        public SavePublicKeyCommandHandler(IUserKeyRepositry userKeyRepository)
        {
            _userKeyRepository = userKeyRepository;
        }

        public async Task<SavePublicKeyResponse> Handle(SaveKeysCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Basit kontrol
                if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrEmpty(request.PublicKey))
                {
                    return new SavePublicKeyResponse
                    {
                        Success = false,
                        Message = "UserId ve PublicKey boş olamaz"
                    };
                }

                // Mevcut key kontrolü
                var existingKey = await _userKeyRepository.GetByUserIdAsync(request.UserId);
                bool result;

                if (existingKey != null)
                {
                    // Key güncelleme
                    
                    return new SavePublicKeyResponse
                    {
                        Success = true,
                        Message = "Key Bulunmakta" 
                    };
                }

                // Yeni key kaydetme
                result = await _userKeyRepository.SaveKeyAsync(request.UserId, request.PublicKey,request.EncryptedPrivateKey,request.iv);
                return new SavePublicKeyResponse
                {
                    Success = result,
                    Message = result ? "Public key başarıyla kaydedildi" : "Public key kaydedilemedi"
                };
            }
            catch (Exception ex)
            {
                return new SavePublicKeyResponse
                {
                    Success = false,
                    Message = $"Bir hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
