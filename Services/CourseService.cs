using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Services
{
    internal sealed class CourseService : ICourseService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CourseService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync(CancellationToken cancellationToken = default)
        {
            var courses = await _repositoryManager.CourseRepository.GetAllCoursesAsync(cancellationToken);

            var coursesDto = courses.Adapt<IEnumerable<CourseDto>>();

            return coursesDto;
        }
        public async Task<CourseDto> GetCoursesByIdAsync(Guid courseId, CancellationToken cancellationToken = default)
        {
            var course = await _repositoryManager.CourseRepository.GetCoursesByIdAsync(courseId, cancellationToken);

            if (course is null)
            {
                throw new CourseNotFoundException(courseId);
            }

            var courseDto = course.Adapt<CourseDto>();

            return courseDto;
        }
        public async Task<CourseDto> CreateCourseAsync(CourseForCreationDto courseForCreationDto, CancellationToken cancellationToken = default)
        {
            var course = courseForCreationDto.Adapt<Course>();

            _repositoryManager.CourseRepository.InsertCourse(course);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return course.Adapt<CourseDto>();
        }

    }
}
