using System.Collections.Generic;
using System.Threading.Tasks;
using CoksaProject.Models;

namespace CoksaProject.ViewModels
{
    public class CandidateDetailsViewModel
    {
        public Candidate Candidate { get; set; }

        public  Tasks Tasks { get; set; }
        
        public List<CandidateTasks> CandidateTasks { get; set; }
        public string PageTitle { get; set; }


    }
}