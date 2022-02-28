using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDateRepository
    {
        Task<IEnumerable<Date>> GetAllDatesAsync(CancellationToken cancellationToken = default);
        Task<Date> GetDatesByIdAsync(Guid dateId, CancellationToken cancellationToken = default);
        void InsertDate(Date date);
    }
}
