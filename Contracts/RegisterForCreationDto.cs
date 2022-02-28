using Contracts;
using System;
namespace Services.Contracts
{
    public class RegisterForCreationDto
    {
        public CourseAndDateRelationForCreationDto CDRForCreationDto { get; set; }
        public ParticipantForCreationDto ParticipantForCreationDto { get; set;}
        //public CompanyForCreationDto CompanyForCreationDto { get; set;}
        //public CourseForCreationDto CourseForCreationDto { get; set;} 
        //public DateForCreationDto DateForCreationDto { get; set;} 
    }
}