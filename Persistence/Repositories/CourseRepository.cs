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
    internal class CourseRepository : ICourseRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CourseRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Course>> GetAllCoursesAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Courses.Include(x => x.CourseAndDateRelations).ToListAsync(cancellationToken);

        public async Task<Course> GetCoursesByIdAsync(Guid courseId, CancellationToken cancellationToken = default) =>
            await _dbContext.Courses.Include(x => x.CourseAndDateRelations).FirstOrDefaultAsync(x => x.Id == courseId, cancellationToken);

        public void InsertCourse(Course course) => _dbContext.Courses.Add(course);
    }
}
