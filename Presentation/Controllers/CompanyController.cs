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
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CompanyController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetCompanies(CancellationToken cancellationToken)
        {
            var company = await _serviceManager.CompanyService.GetAllCompaniesAsync(cancellationToken);

            return Ok(company);
        }

        [HttpGet("{copmanyId:guid}")]
        public async Task<IActionResult> GetCompaniesId(Guid companyId, CancellationToken cancellationToken)
        {
            var companyDto = await _serviceManager.CompanyService.GetCompaniesByIdAsync(companyId, cancellationToken);

            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanies([FromBody] CompanyForCreationDto companyForCreationDto)
        {
            var companyDto = await _serviceManager.CompanyService.CreateCompanyAsync(companyForCreationDto);
            return CreatedAtAction(nameof(GetCompaniesId), new { companyId = companyDto.Id }, companyDto);
        }
    }
}
