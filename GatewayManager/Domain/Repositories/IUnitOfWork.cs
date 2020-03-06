using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayManager.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteTask();
    }
}
