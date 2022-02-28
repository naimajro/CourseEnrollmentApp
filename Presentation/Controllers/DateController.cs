using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/date")]
    public class DateController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public DateController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetDates(CancellationToken cancellationToken)
        {
            var date = await _serviceManager.DateService.GetAllDatesAsync(cancellationToken);

            return Ok(date);
        }

        [HttpGet("{dateId:guid}")]
        public async Task<IActionResult> GetDatesById(Guid courseId, Guid dateId, CancellationToken cancellationToken)
        {
            var dateDto = await _serviceManager.DateService.GetDatesByIdAsync(dateId, cancellationToken);

            return Ok(dateDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDates(Guid courseId, [FromBody] DateForCreationDto dateForCreationDto)
        {
            //Guid id = new Guid();
            var dateDto = await _serviceManager.DateService.CreateDateAsync(dateForCreationDto);

            return CreatedAtAction(nameof(GetDatesById), new { dateId = dateDto.Id }, dateDto);
        }

    }
}
