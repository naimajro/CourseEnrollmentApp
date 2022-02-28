using System;

namespace Domain.Exceptions
{
    public sealed class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(Guid courseId)
            : base($"The course with the identifier {courseId} was not found.")    
        {
        }
    }
}
