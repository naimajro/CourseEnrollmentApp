using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CompanyRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Companies.Include(x => x.Participants).ToListAsync(cancellationToken);

        public async Task<Company> GetCompanyByIdAsync(Guid companyId, CancellationToken cancellationToken = default) =>
            await _dbContext.Companies.Include(x => x.Participants).FirstOrDefaultAsync(x => x.Id == companyId, cancellationToken);

        public void InsertCompany(Company company) => _dbContext.Companies.Add(company);
    }
}
