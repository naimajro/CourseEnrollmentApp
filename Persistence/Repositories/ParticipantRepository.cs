using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class ParticipantRepository:IParticipantRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ParticipantRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Participant>> GetAllParticipantsAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Participants.Include(x => x.Name).ToListAsync(cancellationToken);

        public async Task<Participant> GetParticipantsByIdAsync(Guid participantId, CancellationToken cancellationToken = default) =>
            await _dbContext.Participants.Include(x => x.Name).FirstOrDefaultAsync(x => x.Id == participantId, cancellationToken);

        public void InsertParticipant(Participant participant) => _dbContext.Participants.Add(participant);
    }
}
