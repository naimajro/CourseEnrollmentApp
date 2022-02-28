using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Domain.Repositories;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class RegisterRepository : IRegisterRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public RegisterRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Register>> GetAllByRegisteredAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Register.Include(x => x.Id).ToListAsync(cancellationToken);

        public void InsertRegister(Register register) => _dbContext.Register.Add(register);
        public async Task<Register> GetByIdAsync(Guid registerId, CancellationToken cancellationToken = default) =>
        await _dbContext.Register.FirstOrDefaultAsync(x => x.Id == registerId, cancellationToken);


    }
}
