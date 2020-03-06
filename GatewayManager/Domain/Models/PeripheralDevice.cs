using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayManager.Domain.Models
{
    public class PeripheralDevice
    {
        [Key]
        public int PDeviceID { get; set; }

        [Required]
        public string Vendor { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public EDeviceStatus Status { get; set; }

        public int GatewayID { get; set; }

        public Gateway Gateway { get; set; }
    }

    public enum EDeviceStatus { Online, Offline }
}
