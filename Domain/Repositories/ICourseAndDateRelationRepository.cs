using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICourseAndDateRelationRepository
    {
        Task<IEnumerable<CourseAndDateRelation>> GetAllByCDRAsync(CancellationToken cancellationToken = default);
        Task<CourseAndDateRelation> GetCDRByIdAsync(Guid cdr, CancellationToken cancellationToken = default);
        void InsertCDR(CourseAndDateRelation cdr);
    }
}
