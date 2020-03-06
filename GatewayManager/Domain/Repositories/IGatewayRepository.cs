using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;

namespace GatewayManager.Domain.Repositories
{
    public interface IGatewayRepository
    {
        Task<IEnumerable<Gateway>> ListAsync();
        Task<Gateway> FindByID(int id);
        Task SaveAsync(Gateway gateway);
    }
}
