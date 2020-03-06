using GatewayManager.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayManager.Persistence.Repositories
{
    public abstract class DataRepository
    {
        protected readonly GatewayManagerContext _gatewayManagerContext;

        public DataRepository(GatewayManagerContext context)
        {
            _gatewayManagerContext = context;
        }
    }
}
