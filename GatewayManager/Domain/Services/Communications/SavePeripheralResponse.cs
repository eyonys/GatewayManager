using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;

namespace GatewayManager.Domain.Services.Communications
{
    public class PeripheralResponse : BaseResponse
    {
        public PeripheralDevice Peripheral { get; private set; }

        private PeripheralResponse(bool succes, string responseMessage, PeripheralDevice peripheral) : base(succes, responseMessage)
        {
            Peripheral = peripheral;
        }

        public PeripheralResponse(PeripheralDevice peripheral) : this(true, "", peripheral) { }

        public PeripheralResponse(string message) : this(false, message, null) { }
    }
}
