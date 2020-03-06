using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayManager.Domain.Models
{
    public class Gateway
    {
        [Key]
        public int GatewayID { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string IPAddress { get; set; }

        [Required]
        public IList<PeripheralDevice> Peripherals { get; private set; } = new List<PeripheralDevice>();
    }
}
