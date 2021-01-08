using System.Collections.Generic;

namespace CoksaProject.Models
{
    public class Hours
    {
        public int ID { get; set; }
        public int HoursN { get; set; }
        public ICollection<CandidateTasks> CandidateTaskses { get; set; }
      
    }
}