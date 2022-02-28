using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CompanyService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(CancellationToken cancellationToken = default)
        {
            var companies = await _repositoryManager.CompanyRepository.GetAllCompaniesAsync(cancellationToken);

            var companiesDto = companies.Adapt<IEnumerable<CompanyDto>>();

            return companiesDto;
        }
        public async Task<CompanyDto> GetCompaniesByIdAsync(Guid companyId, CancellationToken cancellationToken = default)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyByIdAsync(companyId, cancellationToken);

            if (company is null)
            {
                throw new Exception();/*new NotFoundException();*/
                /* OwnerNotFoundException(ownerId);*/
            }

            var companyDto = company.Adapt<CompanyDto>();

            return companyDto;
        }
        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto companyForCreationDto, CancellationToken cancellationToken = default)
        {
            var company = companyForCreationDto.Adapt<Company>();

            _repositoryManager.CompanyRepository.InsertCompany(company);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return company.Adapt<CompanyDto>();
        }

    }
}
