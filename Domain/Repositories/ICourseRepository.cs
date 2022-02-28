using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(CancellationToken cancellationToken = default);
        Task<Course> GetCoursesByIdAsync(Guid courseId, CancellationToken cancellationToken = default);
        void InsertCourse(Course course);
    }
}
