namespace Services.Abstractions
{
    public interface IServiceManager
    {
        ICourseService CourseService { get; }

        ICompanyService CompanyService { get; }
        IParticipantService ParticipantService { get; }

        IRegisterService RegisterService { get; }
        IDateService DateService { get; }
        ICourseAndDateRelationService CourseAndDateRelationService { get; }
    }
}
