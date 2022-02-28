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
    public interface ICourseAndDateRelationService
    {
        Task<IEnumerable<CourseAndDateRelationDto>> GetAllCDRAsync(CancellationToken cancellationToken = default);
        Task<CourseAndDateRelationDto> GetCDRByIdAsync(Guid cdrId, CancellationToken cancellationToken = default);

        Task<CourseAndDateRelationDto> CreateCDRAsync(CourseAndDateRelationForCreationDto cdrForCreationDto, CancellationToken cancellationToken = default);

    }
}
