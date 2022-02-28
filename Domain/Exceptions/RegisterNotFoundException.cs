using System;

namespace Domain.Exceptions
{
    public sealed class RegisterNotFoundException : NotFoundException
    {
        public RegisterNotFoundException(Guid registerId)
            : base($"The register with the identifier {registerId} was not found.")
        {
        }
    }
}
