using Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(CancellationToken cancellationToken = default);
        Task<CompanyDto> GetCompaniesByIdAsync(Guid companyId, CancellationToken cancellationToken = default);

        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto companyForCreationDto, CancellationToken cancellationToken = default);

    }
}
