using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserKey
    {
        [Key]
          public int Id { get; set; }
    public string UserId { get; set; }
    public string PublicKey { get; set; }
    public string iv { get; set; }
    public string EncryptedPrivateKey { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    }
}