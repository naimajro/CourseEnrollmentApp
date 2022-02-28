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
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCoursesAsync(CancellationToken cancellationToken = default);
        Task<CourseDto> GetCoursesByIdAsync(Guid courseId, CancellationToken cancellationToken = default);

        Task<CourseDto> CreateCourseAsync(CourseForCreationDto courseForCreationDto, CancellationToken cancellationToken = default);

    }
}
