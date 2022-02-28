using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class CourseAndDateRelationDto
    {
        public Guid Id { get; set; }
        public Guid DateId { get; set; }
        public Guid CourseId { get; set; }
        public IEnumerable<Register> Registers { get; set; }
    }
}
