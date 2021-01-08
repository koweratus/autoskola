namespace CoksaProject.Models
{
    public class CandidateTasks
    {
        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        public int TasksID { get; set; }
        public Tasks Tasks { get; set; }

        public int HoursID { get; set; }

        public Hours Hours { get; set; }
    }
}