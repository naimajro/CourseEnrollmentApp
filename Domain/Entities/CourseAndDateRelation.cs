using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseAndDateRelation
    {
        public Guid Id { get; set; }
        public Guid DateId { get; set; }
        public Guid CourseId { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}
