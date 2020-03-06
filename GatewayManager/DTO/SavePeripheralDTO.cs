using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayManager.DTO
{
    public class SavePeripheralDTO
    {
        [Required]
        public string Vendor { get; set; }
        [Required]
        public string CreationDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string GatewayID { get; set; }
    }
}
