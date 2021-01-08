using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoksaProject.Models
{
    public class DrivingSchool
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Established { get; set; }

        public ICollection<ApplicationUser> Instructors { get; set; }
        public ICollection<DrivingSchoolCars> DrivingSchoolCarz { get; set; }
    }
}