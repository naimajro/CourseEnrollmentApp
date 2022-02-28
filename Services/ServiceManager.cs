using System;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICourseService> _lazyCourseService;
        private readonly Lazy<ICompanyService> _lazyCompanyService;
        private readonly Lazy<IParticipantService> _lazyPartipantService;
        private readonly Lazy<IDateService> _lazyDateService;
        private readonly Lazy<ICourseAndDateRelationService> _lazyCDRService;
        private readonly Lazy<IRegisterService> _lazyRegisterService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCourseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager));
            _lazyCompanyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager));
            _lazyPartipantService = new Lazy<IParticipantService>(() => new ParticipantService(repositoryManager));
            _lazyDateService = new Lazy<IDateService>(() => new DateService(repositoryManager));
            _lazyCDRService = new Lazy<ICourseAndDateRelationService>(() => new CourseAndDateRelationService(repositoryManager));
            _lazyRegisterService = new Lazy<IRegisterService>(() => new RegisterService(repositoryManager));
        }

        public ICourseService CourseService => _lazyCourseService.Value;
        public ICompanyService CompanyService => _lazyCompanyService.Value;
        public IParticipantService ParticipantService => _lazyPartipantService.Value;
        public IDateService DateService => _lazyDateService.Value;
        public ICourseAndDateRelationService CourseAndDateRelationService => _lazyCDRService.Value;
        public IRegisterService RegisterService => _lazyRegisterService.Value;
    }
}
