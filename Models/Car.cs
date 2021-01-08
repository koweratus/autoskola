using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CoksaProject.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int ManufactureYear { get; set; }
  
        public ICollection<ApplicationUser> Instructors { get; set; }
        public ICollection<DrivingSchoolCars> DrivingSchoolCarz { get; set; }

    }
}