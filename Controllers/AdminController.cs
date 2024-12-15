using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Women_Empowerment.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

namespace Women_Empowerment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly WomenEmpowerment _context;

        public AdminController(ILogger<AdminController> logger, WomenEmpowerment context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public async Task<IActionResult> NgoAdd()
        {
            try
            {
                var pendingNgos = await _context.NGOs.Where(ngo => ngo.Status == "Pending").ToListAsync();
                return View(pendingNgos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending NGOs: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> NgoAdd(int ngoId)
        {
            var ngo = await _context.NGOs.FindAsync(ngoId);

            if (ngo == null)
            {
                return NotFound();
            }

            ngo.Status = "Success";

            await _context.SaveChangesAsync();

            return RedirectToAction("NgoAdd");
        }
        public async Task<IActionResult> NgoRemove()
        {
            try
            {
                var pendingNgos = await _context.NGOs.Where(ngo => ngo.Status == "Success").ToListAsync();
                return View(pendingNgos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending NGOs: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NgoRemove(int ngoId)
        {
            var ngo = await _context.NGOs.FindAsync(ngoId);

            if (ngo == null)
            {
                return NotFound();
            }

            _context.NGOs.Remove(ngo);

            await _context.SaveChangesAsync();

          
            return RedirectToAction("NgoRemove");
        }
        public async Task<IActionResult> NgoUpdate()
        {
            try
            {
                var pendingNgos = await _context.NGOs.Where(ngo => ngo.Status == "Success").ToListAsync();
                return View(pendingNgos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending NGOs: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NgoUpdate(int ngoId, string name, string location, string trainingSectors, string contactDetails, string status)
        {
        
            var ngo = await _context.NGOs.FindAsync(ngoId);

            if (ngo == null)
            {
                return NotFound();
            }

            ngo.Name = name;
            ngo.Location = location;
            ngo.TrainingSectors = trainingSectors;
            ngo.ContactDetails = contactDetails;
            ngo.Status = status;

            await _context.SaveChangesAsync();

            return RedirectToAction("NgoUpdate");
        }
        public async Task<IActionResult> TraineeAdd()
        {
            try
            {
                var pendingTrainees = await _context.Trainees.Where(Trainee => Trainee.Status == "Pending").ToListAsync();
                return View(pendingTrainees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending Trainees: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> TraineeAdd(int traineeId)
        {
            var trainee = await _context.Trainees.FindAsync(traineeId);

            if (trainee == null)
            {
                return NotFound();
            }

            trainee.Status = "Success";

            await _context.SaveChangesAsync();

            return RedirectToAction("TraineeAdd");
        }

        public async Task<IActionResult> TraineeRemove()
        {
            try
            {
                var pendingTrainees = await _context.Trainees.Where(Trainee => Trainee.Status == "Success").ToListAsync();
                return View(pendingTrainees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending Trainees: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TraineeRemove(int traineeId)
        {
        
            var trainee = await _context.Trainees.FindAsync(traineeId);

            if (trainee == null)
            {
                return NotFound();
            }

            _context.Trainees.Remove(trainee);

            await _context.SaveChangesAsync();

            return RedirectToAction("TraineeRemove"); 
        }
        public async Task<IActionResult> TraineeUpdate()
        {
            try
            {
                var pendingTrainees = await _context.Trainees.Where(Trainee => Trainee.Status == "Success").ToListAsync();
                return View(pendingTrainees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending Trainees: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TraineeUpdate(int traineeId, string name, string course, string courseDuration, string status)
        {
            var trainee = await _context.Trainees.FindAsync(traineeId);

            if (trainee == null)
            {
                return NotFound();
            }

            trainee.Name = name;
            trainee.Course = course;
            trainee.CourseDuration = courseDuration;
            trainee.Status = status;

            await _context.SaveChangesAsync();

            return RedirectToAction("TraineeUpdate"); 
        }
    }
}