using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;

namespace GatewayManager.Domain.Services.Communications
{
    public class GatewayResponse : BaseResponse
    {
        public Gateway Gateway { get; private set; }

        private GatewayResponse(bool succes, string responseMessage, Gateway gateway) : base(succes, responseMessage)
        {
            Gateway = gateway;
        }

        public GatewayResponse(Gateway gateway): this(true, "", gateway) { }

        public GatewayResponse(string message) : this(false, message, null) { }
    }
}
