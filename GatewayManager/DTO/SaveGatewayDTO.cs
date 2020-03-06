using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GatewayManager.DTO
{
    public class SaveGatewayDTO
    {
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$")]
        public string IPAddress { get; set; }
    }
}
