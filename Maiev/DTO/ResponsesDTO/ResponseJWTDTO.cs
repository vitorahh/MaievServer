using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.DTO.ResponsesDTO
{
    public class ResponseJWTDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
