using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoksaProject.Data;
using CoksaProject.Models;
using CoksaProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoksaProject.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IRepository<Candidate> _candidateRepository;
        private readonly IRepository<Tasks> _tasksRepository;
        private readonly IRepository<Hours> _hoursRepository;
        private readonly IRepository<CandidateTasks> _candidateTasksRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
            

        public CandidatesController(IRepository<Candidate> candidateRepository,
            UserManager<ApplicationUser> userManager, ApplicationDbContext context, IRepository<Tasks> tasksRepository, IRepository<CandidateTasks> candidateTasksRepository, IRepository<Hours> hoursRepository)
        {
            _candidateRepository = candidateRepository;
            _userManager = userManager;
            _context = context;
            _tasksRepository = tasksRepository;
            _candidateTasksRepository = candidateTasksRepository;
            _hoursRepository = hoursRepository;
        }

        // GET
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = _candidateRepository.GetAll();

            return View(model.Where(I => I.Instructor == user));
        }

        [HttpGet]
        [Authorize]

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create
            (CandidateCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*string uniqueFileName =
                    ProcessUploadedFile(model);*/
                var user = await _userManager.GetUserAsync(User);

                Candidate newCandidate = new Candidate
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MobileNumber = model.MobileNumber,
                    DateOfBirth = model.DateOfBirth,
                    FirstAidPassed = model.FirstAidPassed,
                    DriverTestPassed = model.DriverTestPassed,
                    Instructor = user
                };
                _candidateRepository.Add(newCandidate);
                /*_candidateTasksRepository.Add(newCandidate.ID)
                */
                    
                return RedirectToAction("Index", new
                {
                    id =
                        newCandidate.ID
                });
            }

            return View();
        }

  
        public async Task<ViewResult> Details(int? id)
        {
            Candidate candidate = _candidateRepository.Get(id.Value);
            HttpContext.Session.SetString("SessionUser",
                JsonConvert.SerializeObject(candidate));
          //  var task = _tasksRepository.Get(id.Value);
            if (candidate == null)
            {
                Response.StatusCode = 404;
                // return View("EmployeeNotFound", id.Value);
            }
            var player = await _context.CandidateTaskses
                .Include(one => one.Candidate)
                .Include(two=>two.Tasks).Where(c=>c.CandidateID==candidate.ID)
                .Include(three=>three.Hours).Where(c=>c.CandidateID==candidate.ID)
                .ToListAsync();

       
            
            CandidateDetailsViewModel candidateDetailsViewModel = new CandidateDetailsViewModel()
                {
                    Candidate = candidate,
                    PageTitle = "Candidate details",
                 //   Tasks = task,
                    CandidateTasks = player
   
                };
            
            
            return View(candidateDetailsViewModel );
        }

        [HttpGet]
        [Authorize]

        public ViewResult Edit(int id)
        {
            Candidate candidate = _candidateRepository
                .Get(id);
            CandidateEditViewModel editModel =
                new CandidateEditViewModel
                {
                    ID = candidate.ID,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    MobileNumber = candidate.MobileNumber,
                    DateOfBirth = candidate.DateOfBirth,
                    FirstAidPassed = candidate.FirstAidPassed,
                    DriverTestPassed = candidate.DriverTestPassed
                 //   ExistingPhotoPath = candidate.PhotoPath
                };
            return View(editModel);
        }

        [HttpPost]
        public IActionResult Edit
            (CandidateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Candidate candidate = _candidateRepository
                    .Get(model.ID);
                candidate.FirstName = model.FirstName;
                candidate.LastName = model.LastName;
                candidate.MobileNumber = model.MobileNumber;
                candidate.DateOfBirth = model.DateOfBirth;
                candidate.FirstAidPassed =model.FirstAidPassed;
                candidate.DriverTestPassed =model.DriverTestPassed;
                /*if (model.Photos != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filepath = Path.Combine
                        (_hostingEnvironment
                                .WebRootPath,
                            "img", model.ExistingPhotoPath);
                        System.IO.File.Delete(filepath);
                    }

                    employee.PhotoPath = ProcessUploadedFile
                        (model);
                }*/

                _candidateRepository.Update(candidate);

                return RedirectToAction("Index", new
                {
                    id = candidate.ID
                });
            }

            return View();
        }
        
        [HttpPost]
        [Authorize]

        public IActionResult Delete
            (CandidateDeleteViewModel model)
        {
            
          
                Candidate candidate = _candidateRepository
                    .Get(model.ID);
             
                _candidateRepository.Delete(candidate.ID);

    

            return RedirectToAction("Index");
        }
        
         [HttpGet]
         [Authorize]
         public ViewResult EditTasks(int id)
         {
             var userInfo = JsonConvert
                 .DeserializeObject<Candidate>(HttpContext.Session
                     .GetString("SessionUser"));
          //   Candidate candidate = userInfo;
          Candidate candidate = _context.Candidates.Single(m => m.ID ==  userInfo.ID);
            
          //   Tasks tasks = _tasksRepository.Get(id);
             Hours hours = _hoursRepository.Get(id);
            TasksEditViewModel editModel =
                 new TasksEditViewModel
                 {
                    // TaskID = tasks.ID,
                     CandidateID = candidate.ID,
                     HoursID = hours.ID,
                     HoursCompleted = hours.HoursN,
                //     HoursNeeded = tasks.Hours
                     
                 };
             return View(editModel);
         }
        
        [HttpPost]

        public IActionResult EditTasks
            (TasksEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Hours hours = _hoursRepository
                    .Get(model.HoursID);
           
                hours.HoursN = model.HoursCompleted;
      

                _hoursRepository.Update(hours);

                return RedirectToAction("Index", new
                {
                    id = hours.ID
                });
            }

            return View();
        }
        
         [Authorize]
           public IActionResult AddTask(int id)
           {
               Candidate candidate = _context.Candidates.Single(m => m.ID == id);
               List<Tasks> taskses = _context.Taskses.ToList();
               return View(new CandidateTasksCreateViewModel(candidate, taskses));
           }

           [HttpPost]
           public IActionResult AddTask(CandidateTasksCreateViewModel candidateTasksCreateViewModel)
           {
               if (ModelState.IsValid)
               {
                   var taskID = candidateTasksCreateViewModel.TasksID;
                   var candidateID = candidateTasksCreateViewModel.CandidateID;

                   IList<CandidateTasks> existingItems = _context.CandidateTaskses
                       .Where(ct => ct.TasksID == taskID)
                       .Where(ct => ct.CandidateID == candidateID).ToList();

                   if (existingItems.Count == 0)
                   {   Hours newCandidate = new Hours()
                       {
                           HoursN = candidateTasksCreateViewModel.Horas
                       };
                       CandidateTasks candidateTasks = new CandidateTasks
                       {
                           Tasks = _context.Taskses.Single(t => t.ID == taskID),
                           Candidate = _context.Candidates.Single(c => c.ID == candidateID),
                           Hours =  _hoursRepository.Add(newCandidate)
                       };
                    
                      
                       _context.CandidateTaskses.Add(candidateTasks);
                       _context.SaveChanges();
                       
                   }

                   return Redirect(string.Format("/Candidates/Index/{0}", candidateTasksCreateViewModel.Candidate));
               }

               return View (candidateTasksCreateViewModel);
           }
    }
}