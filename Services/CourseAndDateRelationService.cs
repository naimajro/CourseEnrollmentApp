using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    internal sealed class CourseAndDateRelationService : ICourseAndDateRelationService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CourseAndDateRelationService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;


        [ActionName(nameof(GetAllCDRAsync))]
        public async Task<IEnumerable<CourseAndDateRelationDto>> GetAllCDRAsync(CancellationToken cancellationToken = default)
        {
            var cdr = await _repositoryManager.CourseAndDateRelationRepository.GetAllByCDRAsync(cancellationToken);

            var cdrDto = cdr.Adapt<IEnumerable<CourseAndDateRelationDto>>();

            return cdrDto;
        }

        public async Task<CourseAndDateRelationDto> GetCDRByIdAsync(Guid cdrId, CancellationToken cancellationToken = default)
        {
            var cdr = await _repositoryManager.CourseAndDateRelationRepository.GetCDRByIdAsync(cdrId, cancellationToken);

            if (cdr is null)
            {
                throw new Exception();
            }

            var cdrDto = cdr.Adapt<CourseAndDateRelationDto>();

            return cdrDto;
        }

        public async Task<CourseAndDateRelationDto> CreateCDRAsync(CourseAndDateRelationForCreationDto cdrForCreationDto, CancellationToken cancellationToken = default)
        {
            //search by courseName if it exists use the id in cdr, otherwise create it
            var course = cdrForCreationDto.CourseForCreationDto.Adapt<Course>();
            _repositoryManager.CourseRepository.InsertCourse(course);

            var date = cdrForCreationDto.DateForCreationDto.Adapt<Date>();
            _repositoryManager.DateRepository.InsertDate(date);

            //Date ID and Course ID in order to create CDR row


            var cdr = cdrForCreationDto.Adapt<CourseAndDateRelation>();
            cdr.DateId = date.Id;
            cdr.CourseId = course.Id;
            _repositoryManager.CourseAndDateRelationRepository.InsertCDR(cdr);
         
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return cdr.Adapt<CourseAndDateRelationDto>();
        }


    }
}