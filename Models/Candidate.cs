using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoksaProject.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "First Name cannot exceed 50 characters")]

        public string FirstName { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Last Name cannot exceed 50 characters")]

        public string LastName { get; set; }
      
        public int MobileNumber{ get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth{ get; set; }
        [Required]
        public bool FirstAidPassed { get; set; }
        [Required]
        public bool HoursDriven { get; set; }
        [Required]
        public bool DriverTestPassed { get; set; }
        
        public ApplicationUser Instructor { get; set; }
        public ICollection<CandidateTasks> CandidateTaskses { get; set; }

    }
}