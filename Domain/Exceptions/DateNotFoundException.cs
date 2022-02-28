using System;

namespace Domain.Exceptions
{
    public sealed class DateNotFoundException : NotFoundException
    {
        public DateNotFoundException(Guid dateId)
            : base($"The date with the identifier {dateId} was not found.")    
        {
        }
    }
}
