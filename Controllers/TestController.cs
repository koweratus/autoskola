using System;
using System.Linq;

using System.Threading.Tasks;
using CoksaProject.Data;
using CoksaProject.Models;
using CoksaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace CoksaProject.Controllers
{
    public class TestController : Controller
    {
        private readonly IRepository<Tasks> _candidateRepository;
        private readonly IRepository<Hours> _hoursRepository;
        private readonly ApplicationDbContext _context;

        public TestController(IRepository<Tasks> candidateRepository, ApplicationDbContext context, IRepository<Hours> hoursRepository)
        {
            _candidateRepository = candidateRepository;
            _context = context;
            _hoursRepository = hoursRepository;
        }

        // GET
        public IActionResult Index()
       {
          
           return View();
       }
         public IActionResult LoadData()  
        {  
            try  
            {  
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();  
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();  
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();  
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();  
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();  
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();  
  
                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;  
                int skip = start != null ? Convert.ToInt32(start) : 0;  
                int recordsTotal = 0;  
  
                // Getting all Customer data  
                var customerData = (from tempcustomer in _context.Taskses  
                                    select tempcustomer);  
  
                //Sorting  
                /*if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))  
                 {  
                     customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);  
                 } */ 
                //Search  
                if (!string.IsNullOrEmpty(searchValue))  
                {  
                    customerData = customerData.Where(m => m.CodeName == searchValue);  
                }  
  
                //total number of rows count   
                recordsTotal = customerData.Count();  
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();  
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });  
  
            }  
            catch (Exception)  
            {  
                throw;  
            }  
  
        }  
  
         [HttpGet]
         public ViewResult Create()
         {
             return View();
         }

         [HttpPost]
         public IActionResult Create
             (CandidateCreateViewModel model)
         {
             if (ModelState.IsValid)
             {
                 /*string uniqueFileName =
                     ProcessUploadedFile(model);*/
                // var user = await _userManager.GetUserAsync(User);

                 Hours newCandidate = new Hours()
                 {
                     HoursN = model.Horas
                 };
                 _hoursRepository.Add(newCandidate);
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
    }
    }
