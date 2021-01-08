using System.Linq;
using System.Threading.Tasks;
using CoksaProject.Data;
using CoksaProject.Models;
using CoksaProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoksaProject.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public InstructorsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            var users = _userManager.Users;
            /*var ds = _userManager.Users
                .Include(m => m.DrivingSchool)   // ADD THIS INCLUDE
                .ToList();
            var drivingSchool = users.;*/
            return View(users);
           
        }
        public async Task<IActionResult> ViewInstructor
        (string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var ds = _userManager.Users
                .Include(m => m.DrivingSchool)   // ADD THIS INCLUDE
                .ToList();
            var drivingSchool = user.DrivingSchool;
            
               var carList = _userManager.Users
                .Include(m => m.Car)   // ADD THIS INCLUDE
                .ToList();
            var car = user.Car;
           
          
            
         

            var model = new InstructorDetailsViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName= user.LastName,
                UserName = user.UserName,
                DrivingSchool = drivingSchool,
                Car = car
     
            };

            return View(model);
           
        }
    }
}