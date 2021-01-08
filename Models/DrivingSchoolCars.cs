namespace CoksaProject.Models
{
    public class DrivingSchoolCars
    {
        public int DrivingSchoolID { get; set; }
        public DrivingSchool DrivingSchool { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}