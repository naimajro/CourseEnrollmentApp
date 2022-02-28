using System;

namespace Domain.Exceptions
{
    public sealed class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid companyId)
            : base($"The company with the identifier {companyId} was not found.")    
        {
        }
    }
}
