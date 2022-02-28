using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CourseController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetCourses(CancellationToken cancellationToken)
        {
            var courses = await _serviceManager.CourseService.GetAllCoursesAsync(cancellationToken);

            return Ok(courses);
        }

        [HttpGet("{courseId:guid}")]
        public async Task<IActionResult> GetCoursesId(Guid coursesId, CancellationToken cancellationToken)
        {
            var courseDto = await _serviceManager.CourseService.GetCoursesByIdAsync(coursesId, cancellationToken);

            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourses([FromBody] CourseForCreationDto courseForCreationDto)
        {
            var courseDto = await _serviceManager.CourseService.CreateCourseAsync(courseForCreationDto);

            return CreatedAtAction(nameof(GetCoursesId), new { courseId = courseDto.Id }, courseDto);
        }

    }
}
