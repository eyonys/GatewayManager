using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using GatewayManager.Domain.Models;
using GatewayManager.Persistence.Contexts;
using GatewayManager.Domain.Services;
using AutoMapper;
using GatewayManager.DTO;
using GatewayManager.Mapping;

namespace GatewayManager.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GatewaysController : ControllerBase
    {
        private readonly GatewayManagerContext _context;
        private readonly IGatewayService _gatewayService;
        private readonly IMapper _mapper;

        public GatewaysController(IGatewayService gatewayService, GatewayManagerContext context, IMapper mapper)
        {
            _gatewayService = gatewayService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GatewayDTO>> GetGateways()
        {
            var gateways = await _gatewayService.ListAsync();
            var gatewaysResource = _mapper.Map<IEnumerable<Gateway>, IEnumerable<GatewayDTO>>(gateways);

            return gatewaysResource;
        }

        // GET: api/Gateways/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GatewayDTO>> GetGateway(int id)
        {
            var gateway = await _gatewayService.FindByIDAsync(id);

            if (gateway == null)
            {
                return NotFound();
            }

            var gatewayInBD = _mapper.Map<Gateway, GatewayDTO>(gateway);

            return gatewayInBD;
        }

        [HttpPost]
        public async Task<ActionResult<GatewayDTO>> PostGateway([FromBody]SaveGatewayDTO gateway)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(me => me.Errors).Select(e => e.ErrorMessage));

            var newGateway = _mapper.Map<SaveGatewayDTO, Gateway>(gateway);
            var result = await _gatewayService.SaveAsync(newGateway);

            if (!result.Success)
                return BadRequest(result.ResponseMessage);

            var createdGateway = _mapper.Map<Gateway, GatewayDTO>(result.Gateway);

            return CreatedAtAction("GetGateway", new { id = createdGateway.GatewayID }, createdGateway);
        }

        private bool GatewayExists(int id)
        {
            return _context.Gateway.Any(e => e.GatewayID == id);
        }
    }
}
