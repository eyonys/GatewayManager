using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewayManager.Domain.Models;
using GatewayManager.Domain.Repositories;
using GatewayManager.Domain.Services;
using GatewayManager.Domain.Services.Communications;

namespace GatewayManager.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public GatewayService(IGatewayRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Gateway> FindByIDAsync(int id)
        {
            return await _repo.FindByID(id);
        }

        public async Task<IEnumerable<Gateway>> ListAsync()
        {
            return await _repo.ListAsync();
        }

        public async Task<GatewayResponse> SaveAsync(Gateway gateway)
        {
            try
            {
                await _repo.SaveAsync(gateway);
                await _unitOfWork.CompleteTask();

                return new GatewayResponse(gateway);
            }
            catch (Exception ex)
            {
                return new GatewayResponse($"An error ocurred triying to save the Gateway : {ex.Message}");
            }
        }
    }
}
