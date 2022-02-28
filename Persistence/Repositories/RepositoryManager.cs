using System;
using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<ICourseRepository> _lazyCourseRepository;
        private readonly Lazy<ICompanyRepository> _lazyCompanyRepository;
        private readonly Lazy<IParticipantRepository> _lazyPartipantRepository;
        private readonly Lazy<IDateRepository> _lazyDateRepository;
        private readonly Lazy<ICourseAndDateRelationRepository> _lazyCDRRepository;
        private readonly Lazy<IRegisterRepository> _lazyRegisterRepository;
        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
            _lazyCourseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(dbContext));
            _lazyCompanyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(dbContext));
            _lazyPartipantRepository = new Lazy<IParticipantRepository>(() => new ParticipantRepository(dbContext));
            _lazyDateRepository = new Lazy<IDateRepository>(() => new DateRepository(dbContext));
            _lazyCDRRepository = new Lazy<ICourseAndDateRelationRepository>(() => new CourseAndDateRelationRepository(dbContext));
            _lazyRegisterRepository = new Lazy<IRegisterRepository>(() => new RegisterRepository(dbContext));
        }
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public ICourseRepository CourseRepository=> _lazyCourseRepository.Value;
        public ICompanyRepository CompanyRepository => _lazyCompanyRepository.Value;
        public IParticipantRepository ParticipantRepository=> _lazyPartipantRepository.Value;
        public IDateRepository DateRepository => _lazyDateRepository.Value;
        public ICourseAndDateRelationRepository CourseAndDateRelationRepository => _lazyCDRRepository.Value;
        public IRegisterRepository RegisterRepository => _lazyRegisterRepository.Value;
    }
}
