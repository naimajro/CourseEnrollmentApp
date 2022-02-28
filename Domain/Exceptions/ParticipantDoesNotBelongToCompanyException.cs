using System;

namespace Domain.Exceptions
{
    public sealed class ParticipantDoesNotBelongToCompanyException : BadRequestException
    {
        public ParticipantDoesNotBelongToCompanyException(Guid companyId, Guid participantId)
            : base($"The participant with the identifier {companyId} does not belong to the company with the identifier {participantId}")
        {
        }
    }
}
