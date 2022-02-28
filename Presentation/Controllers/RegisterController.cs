using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public RegisterController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("{registerId:guid}")]
        public async Task<IActionResult> GetRegisterId(Guid registerId, CancellationToken cancellationToken)
        {
            var registerDto = await _serviceManager.RegisterService.GetByIdAsync(registerId, cancellationToken);

            return Ok(registerDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRegister([FromBody] RegisterForCreationDto registerForCreationDto, CancellationToken cancellationToken)
        {
            //Guid id = new Guid();
            var response = await _serviceManager.RegisterService.CreateRegisterAsync(registerForCreationDto,cancellationToken);

            return CreatedAtAction(nameof(GetRegisterId), new { registerId = response.Id });
        }
    }
}
