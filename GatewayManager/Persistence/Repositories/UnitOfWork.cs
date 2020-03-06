using GatewayManager.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Persistence.Contexts;

namespace GatewayManager.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GatewayManagerContext _gatewayManagerContext;

        public UnitOfWork(GatewayManagerContext context)
        {
            _gatewayManagerContext = context;
        }

        public async Task CompleteTask()
        {
            await _gatewayManagerContext.SaveChangesAsync();
        }
    }
}
