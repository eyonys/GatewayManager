using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;
using GatewayManager.DTO;
using GatewayManager.Domain.Services.Communications;

namespace GatewayManager.Domain.Services
{
    public interface IGatewayService
    {
        Task<IEnumerable<Gateway>> ListAsync();
        Task<Gateway> FindByIDAsync(int id);
        Task<GatewayResponse> SaveAsync(Gateway gateway);
    }
}
