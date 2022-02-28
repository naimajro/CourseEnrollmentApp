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
    internal sealed class ParticipantService : IParticipantService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ParticipantService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<ParticipantDto>> GetAllParticipantsAsync(CancellationToken cancellationToken = default)
        {
            var participants = await _repositoryManager.ParticipantRepository.GetAllParticipantsAsync(cancellationToken);

            var participantsDto = participants.Adapt<IEnumerable<ParticipantDto>>();

            return participantsDto;
        }
        public async Task<ParticipantDto> GetParticipantsByIdAsync(Guid companyId, Guid participantId, CancellationToken cancellationToken = default)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyByIdAsync(companyId, cancellationToken);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var participant = await _repositoryManager.ParticipantRepository.GetParticipantsByIdAsync(participantId, cancellationToken);

            if (participant is null)
            {
                throw new ParticipantNotFoundException(participantId);
            }

            if (participant.Id != company.Id)
            {
                throw new ParticipantDoesNotBelongToCompanyException(company.Id, participant.Id);
            }

            var participantDto = participant.Adapt<ParticipantDto>();

            return participantDto;
        }
        public async Task<ParticipantDto> CreateParticipantAsync(Guid companyId, ParticipantForCreationDto participantForCreationDto, CancellationToken cancellationToken = default)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyByIdAsync(companyId, cancellationToken);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var participant = participantForCreationDto.Adapt<Participant>();

            participant.CompId = company.Id;

            _repositoryManager.ParticipantRepository.InsertParticipant(participant);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return participant.Adapt<ParticipantDto>();
        }

    }
}
