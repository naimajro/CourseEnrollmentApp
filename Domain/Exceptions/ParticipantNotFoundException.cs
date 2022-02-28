using System;

namespace Domain.Exceptions
{
    public sealed class ParticipantNotFoundException : NotFoundException
    {
        public ParticipantNotFoundException(Guid participantId)
            : base($"The participant with the identifier {participantId} was not found.")    
        {
        }
    }
}
