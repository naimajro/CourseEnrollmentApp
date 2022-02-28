using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Contracts
{
    public class CompanyForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}