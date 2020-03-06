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
    public class GatewayRepository : DataRepository, IGatewayRepository
    {
        public GatewayRepository(GatewayManagerContext context) : base(context) { }

        public async Task<Gateway> FindByID(int id)
        {
            return await _gatewayManagerContext.Gateway.Include(g => g.Peripherals).SingleAsync(g => g.GatewayID == id);
        }

        public async Task<IEnumerable<Gateway>> ListAsync()
        {
            return await _gatewayManagerContext.Gateway.Include(g => g.Peripherals).ToListAsync();
        }

        public async Task SaveAsync(Gateway gateway)
        {
            var gatewayInBD = _gatewayManagerContext.Gateway.Where(g => g.SerialNumber == gateway.SerialNumber);
            if (gatewayInBD.Count() > 0)
                throw new Exception("There is already a gateway with same Serial Number : " + gateway.SerialNumber);
            await _gatewayManagerContext.Gateway.AddAsync(gateway);
        }
    }
}
