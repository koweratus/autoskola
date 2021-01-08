using System;
using System.ComponentModel.DataAnnotations;
using CoksaProject.Models;

namespace CoksaProject.ViewModels
{
    public class CandidateCreateViewModel

    {
        [Required]
        [MaxLength(50, ErrorMessage =
            "First Name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage =
            "Last Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        
        
        [Required]
        [Display(Name = "Mobile Number")]

        public int MobileNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]

        public DateTime DateOfBirth { get; set; }
        [Required]

        [Display(Name = "First Aid Passed")]
        public bool FirstAidPassed { get; set; }
        [Required]

        public bool HoursDriven { get; set; }
        [Required]

        [Display(Name = "Driver Test Passed")]
        public bool DriverTestPassed { get; set; }

        public int Horas { get; set; }

        public ApplicationUser Instructor { get; set; }
    }
}