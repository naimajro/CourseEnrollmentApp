using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Contracts
{
    public class DateForCreationDto
    {
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CourseDate { get; set; }

    }
}