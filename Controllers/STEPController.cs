using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Women_Empowerment.Models;


namespace Women_Empowerment.Controllers
{
    [Authorize(Roles = "STEP")]
    public class STEPController : Controller
    {

        private readonly ILogger<STEPController> _logger;
        private readonly WomenEmpowerment _context;

        public STEPController(ILogger<STEPController> logger, WomenEmpowerment context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult STEPDashboard()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult STEPRegistration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(STEP model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = "Pending";
                    model.RegistrationId = "STEP-" + Guid.NewGuid().ToString();
                    _context.Trainees.Add(model);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"New STEP registration submitted: TraineeId {model.TraineeId}");
                    return RedirectToAction("Status", new { id = model.TraineeId });
                }
                else
                {
                    return View("STEPRegistration");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error submitting STEP registration: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Status(int? id)
        {
            try
            {
                if (id.HasValue && id != 0)
                {
                    var trainee = await _context.Trainees.FindAsync(id.Value);
                    if (trainee == null)
                    {
                        return NotFound();
                    }
                    return View(trainee);
                }
                else
                {
                    var trainees = await _context.Trainees.ToListAsync();

                    return View(trainees);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving STEP status: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        public async Task<IActionResult> RegisteredNgos()
        {
            try
            {
                var registeredNgos = await _context.NGOs.Where(ngo => ngo.Status == "Success").ToListAsync();
                return View(registeredNgos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving pending NGOs: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Guideline()
        {
            return View();
        }
        public IActionResult Agriculture()
        {
            return View();
        }
        public IActionResult Tailoring()
        {
            return View();
        }
        public IActionResult Stitching()
        {
            return View();
        }
        public IActionResult FAq()
        {
            return View();
        }

    }
}
