using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRegisterRepository
    {
        void InsertRegister(Register register);
        Task<Register> GetByIdAsync(Guid registerId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Register>> GetAllByRegisteredAsync(CancellationToken cancellationToken);
        //Task<IEnumerable<Register>> GetRegisterByIdAsync(CancellationToken cancellationToken);
    }
}
