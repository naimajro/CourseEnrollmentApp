using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class CourseDto
    {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public IEnumerable<CourseAndDateRelation> CourseAndDateRelations { get; set; }

    }
}
