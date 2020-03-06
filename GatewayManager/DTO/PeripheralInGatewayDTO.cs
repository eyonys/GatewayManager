using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;

namespace GatewayManager.DTO
{
    public class PeripheralInGatewayDTO
    {
        public int PDeviceID { get; set; }
        public string Vendor { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
    }
}
