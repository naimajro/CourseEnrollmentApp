using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class DateService : IDateService
    {
        private readonly IRepositoryManager _repositoryManager;

        public DateService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<DateDto>> GetAllDatesAsync(CancellationToken cancellationToken = default)
        {
            var dates = await _repositoryManager.DateRepository.GetAllDatesAsync(cancellationToken);

            var datesDto = dates.Adapt<IEnumerable<DateDto>>();

            return datesDto;
        }
        public async Task<DateDto> GetDatesByIdAsync(Guid dateId, CancellationToken cancellationToken = default)
        {
            var course = await _repositoryManager.DateRepository.GetDatesByIdAsync(dateId, cancellationToken);

            if (course is null)
            {
                throw new DateNotFoundException(dateId);
            }

            var date = await _repositoryManager.DateRepository.GetDatesByIdAsync(dateId, cancellationToken);

            if (date is null)
            {
                throw new DateNotFoundException(dateId);
            }

            if (date.Id != course.Id)
            {
                throw new DateNotFoundException(dateId);
            }

            var dateDto = date.Adapt<DateDto>();

            return dateDto;
        }
        public async Task<DateDto> CreateDateAsync(DateForCreationDto dateForCreationDto, CancellationToken cancellationToken = default)
        {
            var date = dateForCreationDto.Adapt<Date>();

            _repositoryManager.DateRepository.InsertDate(date);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return date.Adapt<DateDto>();
        }

    }
}
