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
    public class PeripheralDeviceService : IPeripheralDeviceService
    {
        private readonly IPeripheralDeviceRepository _repo;
        private readonly IGatewayService _gatewayService;
        private readonly IUnitOfWork _unitOfWork;

        public PeripheralDeviceService(IPeripheralDeviceRepository repo, IUnitOfWork unitOfWork, IGatewayService gatewayService)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _gatewayService = gatewayService;
        }

        public async Task<PeripheralResponse> DeleteAsync(int id)
        {
            var peripheral = await _repo.FindByIDAsync(id);
            if (peripheral == null)
                return new PeripheralResponse($"An error ocurred triying to delete the Peripheral Device : Peripheral Device not found.");

            try
            {
                _repo.RemoveAsync(peripheral);
                await _unitOfWork.CompleteTask();

                return new PeripheralResponse(peripheral);
            }
            catch (Exception ex)
            {
                return new PeripheralResponse($"An error ocurred triying to delete the Peripheral Device : {ex.Message}");
            }
        }

        public async Task<PeripheralResponse> SaveAsync(PeripheralDevice peripheral)
        {
            var gateway = await _gatewayService.FindByIDAsync(peripheral.GatewayID);
            if (gateway == null)
                return new PeripheralResponse($"An error ocurred triying to save the Peripheral Device : The specified gateway does not exist.");

            try
            {
                await _repo.SaveAsync(peripheral);
                await _unitOfWork.CompleteTask();

                return new PeripheralResponse(peripheral);
            }
            catch (Exception ex)
            {
                return new PeripheralResponse($"An error ocurred triying to save the Peripheral Device : {ex.Message}");
            }
        }
    }
}
