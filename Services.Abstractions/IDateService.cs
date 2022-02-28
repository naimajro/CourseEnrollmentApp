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
    public interface IDateService
    {
        Task<IEnumerable<DateDto>> GetAllDatesAsync(CancellationToken cancellationToken = default);
        Task<DateDto> GetDatesByIdAsync(Guid dateId, CancellationToken cancellationToken = default);

        Task<DateDto> CreateDateAsync(DateForCreationDto dateForCreationDto, CancellationToken cancellationToken = default);

    }
}
