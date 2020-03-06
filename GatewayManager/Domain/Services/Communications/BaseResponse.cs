using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayManager.Domain.Services.Communications
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string ResponseMessage { get; set; }

        public BaseResponse(bool success, string responseMessage)
        {
            Success = success;
            ResponseMessage = responseMessage;
        }
    }
}
