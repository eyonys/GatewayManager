using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;

namespace GatewayManager.Domain.Repositories
{
    public interface IPeripheralDeviceRepository
    {
        Task<IEnumerable<PeripheralDevice>> ListAsync();
        Task SaveAsync(PeripheralDevice peripheral);

        void RemoveAsync(PeripheralDevice peripheral);
        Task<PeripheralDevice> FindByIDAsync(int id);
    }
}
