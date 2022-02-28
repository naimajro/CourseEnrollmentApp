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
    internal class CourseAndDateRelationRepository : ICourseAndDateRelationRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CourseAndDateRelationRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<CourseAndDateRelation>> GetAllByCDRAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.CoursesAndDateRelations.Include(x => x.Registers).ToListAsync(cancellationToken);
        public async Task<CourseAndDateRelation> GetCDRByIdAsync(Guid cdrId, CancellationToken cancellationToken = default) =>
        await _dbContext.CoursesAndDateRelations.Include(x => x.Registers).FirstOrDefaultAsync(x => x.Id == cdrId, cancellationToken);

        public void InsertCDR(CourseAndDateRelation cdr) => _dbContext.CoursesAndDateRelations.Add(cdr);
       
    }
}
