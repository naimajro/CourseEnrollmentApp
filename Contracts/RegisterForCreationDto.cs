using Contracts;
using System;
using System.Collections.Generic;

namespace Services.Contracts
{
    public class RegisterForCreationDto
    {
        public CourseAndDateRelationForCreationDto CDRForCreationDto { get; set; }
        public List<ParticipantForCreationDto> ParticipantForCreationDto { get; set;}
        public CompanyForCreationDto CompanyForCreationDto { get; set; }
        //public CourseForCreationDto CourseForCreationDto { get; set;} 
        //public DateForCreationDto DateForCreationDto { get; set;} 
    }
}