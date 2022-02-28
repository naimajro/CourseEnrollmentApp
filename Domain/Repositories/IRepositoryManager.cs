namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        ICourseRepository CourseRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IParticipantRepository ParticipantRepository { get; }
        IDateRepository DateRepository { get; }
        IRegisterRepository RegisterRepository { get; }
        ICourseAndDateRelationRepository CourseAndDateRelationRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
