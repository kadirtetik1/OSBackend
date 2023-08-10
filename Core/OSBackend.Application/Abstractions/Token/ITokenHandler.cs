using OSBackend.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBackend.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minutes, Guid userId, string user_name, string fullname);  //Token = Access Token = JWT , aynı şeylerdir
    }
}
