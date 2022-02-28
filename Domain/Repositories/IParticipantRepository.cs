using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAllParticipantsAsync(CancellationToken cancellationToken = default);
        Task<Participant> GetParticipantsByIdAsync(Guid participantId, CancellationToken cancellationToken = default);
        void InsertParticipant(Participant participant);
    }
}
