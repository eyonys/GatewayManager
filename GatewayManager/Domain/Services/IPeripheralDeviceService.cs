using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;
using GatewayManager.DTO;
using GatewayManager.Domain.Services.Communications;

namespace GatewayManager.Domain.Services
{
    public interface IPeripheralDeviceService
    {
        Task<PeripheralResponse> SaveAsync(PeripheralDevice peripheral);
        Task<PeripheralResponse> DeleteAsync(int id);
    }
}