using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoksaProject.Models;

namespace CoksaProject.ViewModels
{
    public class InstructorDetailsViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        
        [Display(Name = "Contact E-mail")]
        public string Email { get; set; }
        [Display(Name = "Driving School")]
        public DrivingSchool DrivingSchool { get; set; }
        public Car Car { get; set; }
    }
}