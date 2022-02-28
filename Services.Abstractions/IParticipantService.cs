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
    public interface IParticipantService
    {
        Task<IEnumerable<ParticipantDto>> GetAllParticipantsAsync(CancellationToken cancellationToken = default);
        Task<ParticipantDto> GetParticipantsByIdAsync(Guid companyId, Guid participantId, CancellationToken cancellationToken = default);
        Task<ParticipantDto> CreateParticipantAsync(Guid companyId, ParticipantForCreationDto participantForCreationDto, CancellationToken cancellationToken = default);

    }
}
