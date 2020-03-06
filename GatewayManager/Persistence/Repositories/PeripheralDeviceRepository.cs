using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GatewayManager.Domain.Models;
using GatewayManager.Domain.Repositories;
using GatewayManager.Persistence.Contexts;


namespace GatewayManager.Persistence.Repositories
{
    public class PeripheralDeviceRepository : DataRepository, IPeripheralDeviceRepository
    {
        public PeripheralDeviceRepository(GatewayManagerContext gatewayManagerContext) : base(gatewayManagerContext) { }

        public async Task<PeripheralDevice> FindByIDAsync(int id)
        {
            return await _gatewayManagerContext.Peripherals.SingleAsync(p => p.PDeviceID == id);
        }

        public async Task<IEnumerable<PeripheralDevice>> ListAsync()
        {
            return await _gatewayManagerContext.Peripherals.ToListAsync();
        }

        public void RemoveAsync(PeripheralDevice peripheral)
        {
            _gatewayManagerContext.Peripherals.Remove(peripheral);
        }

        public async Task SaveAsync(PeripheralDevice peripheral)
        {
            var count = _gatewayManagerContext.Peripherals.Where(p => p.GatewayID == peripheral.GatewayID).ToList().Count;
            if (count < 10)
                await _gatewayManagerContext.Peripherals.AddAsync(peripheral);
            else
                throw new Exception("The gateway can not carry more Peripheral Devices");
        }
    }
}
