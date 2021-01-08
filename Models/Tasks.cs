using System.Collections.Generic;

namespace CoksaProject.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public int Hours { get; set; }
        public int HoursCompleted { get; set; }
        public ICollection<CandidateTasks> CandidateTaskses { get; set; }
    }
}