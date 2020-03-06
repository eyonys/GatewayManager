using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GatewayManager.Domain.Models;
using GatewayManager.Domain.Services;
using GatewayManager.Persistence.Contexts;
using GatewayManager.DTO;

namespace GatewayManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeripheralDevicesController : ControllerBase
    {
        private readonly GatewayManagerContext _context;
        private readonly IPeripheralDeviceService _peripheralService;
        private readonly IMapper _mapper;

        public PeripheralDevicesController(IPeripheralDeviceService peripheralService, GatewayManagerContext context, IMapper mapper)
        {
            _peripheralService = peripheralService;
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PeripheralDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeripheralDevice>>> GetDevices()
        {
            return await _context.Peripherals.ToListAsync();
        }

        // POST: api/PeripheralDevices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PeripheralDeviceDTO>> PostPeripheralDevice([FromBody]SavePeripheralDTO peripheralDevice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(me => me.Errors).Select(e => e.ErrorMessage));

            var newPeripheral = _mapper.Map<SavePeripheralDTO, PeripheralDevice>(peripheralDevice);
            var result = await _peripheralService.SaveAsync(newPeripheral);

            if (!result.Success)
                return BadRequest(result.ResponseMessage);

            var createdPeripheral = _mapper.Map<PeripheralDevice, PeripheralDeviceDTO>(result.Peripheral);

            return CreatedAtAction("GetPeripheral", new { id = createdPeripheral.PDeviceID }, createdPeripheral);
        }

        // DELETE: api/PeripheralDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PeripheralDevice>> DeletePeripheralDevice(int id)
        {
            var result = await _peripheralService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.ResponseMessage);

            var peripheralDeleted = _mapper.Map<PeripheralDevice, PeripheralDeviceDTO>(result.Peripheral);

            return Ok(peripheralDeleted);
        }

        private bool PeripheralDeviceExists(int id)
        {
            return _context.Peripherals.Any(e => e.PDeviceID == id);
        }
    }
}
