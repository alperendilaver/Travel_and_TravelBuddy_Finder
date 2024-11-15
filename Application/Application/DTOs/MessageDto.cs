using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record MessageDto(string SenderId, string ReceiverId, string Content);
}