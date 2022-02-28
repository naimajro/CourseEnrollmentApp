using Domain.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class CourseAndDateRelationForCreationDto
    {
        public DateForCreationDto DateForCreationDto { get; set; }
        public CourseForCreationDto CourseForCreationDto {  get; set; }
    }
}
