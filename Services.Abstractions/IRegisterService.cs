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
    public interface IRegisterService
    {
        Task<RegisterDto> GetByIdAsync(Guid registerId, CancellationToken cancellationToken = default);
        Task<RegisterDto> CreateRegisterAsync(RegisterForCreationDto registerForCreationDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<RegisterDto>> GetAllByRegisteredAsync(CancellationToken cancellationToken);
    }
}
