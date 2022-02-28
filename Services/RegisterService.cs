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
    internal sealed class RegisterService : IRegisterService
    {
        private readonly IRepositoryManager _repositoryManager;
        private CourseAndDateRelationService cdrService;
        public RegisterService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<IEnumerable<RegisterDto>> GetAllByRegisteredAsync(CancellationToken cancellationToken = default)
        {
            var register = await _repositoryManager.RegisterRepository.GetAllByRegisteredAsync(cancellationToken);

            var registerDto = register.Adapt<IEnumerable<RegisterDto>>();

            return registerDto;
        }

        public async Task<RegisterDto> CreateRegisterAsync(RegisterForCreationDto registerForCreationDto,CancellationToken cancellationToken)
        {
            var register = registerForCreationDto.Adapt<Register>();

            var course = registerForCreationDto.CDRForCreationDto.CourseForCreationDto.Adapt<Course>();
            _repositoryManager.CourseRepository.InsertCourse(course);

            var date = registerForCreationDto.CDRForCreationDto.DateForCreationDto.Adapt<Date>();
            _repositoryManager.DateRepository.InsertDate(date);

            var cdr = registerForCreationDto.Adapt<CourseAndDateRelation>();
            cdr.DateId = date.Id;
            cdr.CourseId = course.Id;
            _repositoryManager.CourseAndDateRelationRepository.InsertCDR(cdr);

            var company = registerForCreationDto.ParticipantForCreationDto.CompanyForCreationDto.Adapt<Company>();
            _repositoryManager.CompanyRepository.InsertCompany(company);

            var participant = registerForCreationDto.ParticipantForCreationDto.Adapt<Participant>();
            participant.CompId = company.Id;
            _repositoryManager.ParticipantRepository.InsertParticipant(participant);

            register.CDRId = cdr.Id;
            register.ParticipantId = participant.Id;

            _repositoryManager.RegisterRepository.InsertRegister(register);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return register.Adapt<RegisterDto>();
        }
        public async Task<RegisterDto> GetByIdAsync(Guid registerId, CancellationToken cancellationToken)
        {
            var register = await _repositoryManager.RegisterRepository.GetByIdAsync(registerId, cancellationToken);

            if (register is null)
            {
                throw new RegisterNotFoundException(registerId);
            }

            var registerDto = register.Adapt<RegisterDto>();

            return registerDto;
        }

    }
}
