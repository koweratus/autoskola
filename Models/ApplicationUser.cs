using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CoksaProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public DateTime DateOfBirth{ get; set; }
        public ICollection<Candidate> Candidates { get; set; }


        public Car Car { get; set; }
        
        public DrivingSchool DrivingSchool{ get; set; }
    }
}