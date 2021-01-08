using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CoksaProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoksaProject.ViewModels
{
    public class CandidateTasksCreateViewModel
    {
        public Candidate Candidate { get; set; }
        public List<SelectListItem> Tasks { get; set; }

        public Hours Hours { get; set; }
        
        public List<CandidateTasks> CandidateTasks { get; set; }
        public string PageTitle { get; set; }
        public int CandidateID { get; set; }
        [Display(Name = "Code name")]
        public int TasksID { get; set; }

        public int Horas { get; set; }
        

        public CandidateTasksCreateViewModel()
        {
            
        }

        public CandidateTasksCreateViewModel(Candidate candidate, IEnumerable<Tasks> tasks)
        {
            Tasks = new List<SelectListItem>();

            foreach (var task in tasks)
            {
                Tasks.Add(new SelectListItem
                {
                    Value = task.ID.ToString(),
                    Text = task.CodeName
                });
            }
            
            
            Candidate = candidate;
            
        }
    }
    
}