using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;

namespace GatewayManager.DTO
{
    public class GatewayDTO
    {
        public int GatewayID { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public IList<PeripheralInGatewayDTO> Peripherals { get; private set; } = new List<PeripheralInGatewayDTO>();
    }
}
