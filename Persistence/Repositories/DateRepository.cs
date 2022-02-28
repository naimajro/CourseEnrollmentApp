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
    internal class DateRepository : IDateRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public DateRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Date>> GetAllDatesAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Dates.Include(x => x.CourseAndDateRelations).ToListAsync(cancellationToken);

        public async Task<Date> GetDatesByIdAsync(Guid dateId, CancellationToken cancellationToken = default) =>
            await _dbContext.Dates.FirstOrDefaultAsync(x => x.Id == dateId, cancellationToken);

        public void InsertDate(Date date) => _dbContext.Dates.Add(date);


    }
}
