using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Women_Empowerment.Models;

namespace Women_Empowerment.Controllers
{
    [Authorize(Roles = "NGO")]
    public class NGOsController : Controller
    {
        private readonly ILogger<NGOsController> _logger;
        private readonly WomenEmpowerment _context;

        public NGOsController(ILogger<NGOsController> logger, WomenEmpowerment context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult NGOsDashboard()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Criteria()
        {
            return View();
        }
        //public IActionResult Organizations()
        //{
        //    return View();
        //}

        //public IActionResult FundingNorms()
        //{
        //    return View();
        //}
        public IActionResult NGORegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit( NGO ngo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ngo.Status = "Pending";
                    ngo.RegistrationId = "NGO-" + Guid.NewGuid().ToString();
                    _context.NGOs.Add(ngo);
                    _context.SaveChanges();

                    _logger.LogInformation("NGO Registered successfully: {Name}", ngo.Name);
                    return RedirectToAction("Status", new { id = ngo.NGOId });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error registering NGO: {Name}", ngo.Name);
                    ModelState.AddModelError("", "Failed to register NGO. Please try again later.");
                }
            }
            return View("NGORegistration", ngo);
        }

        [HttpGet]
        public async Task<IActionResult> Status(int? id)
        {
            if (id.HasValue && id != 0)
            {
                var ngo = await _context.NGOs.FindAsync(id.Value);
                if (ngo == null)
                {
                    return NotFound();
                }
                return View(ngo);
            }
            else
            {
                var ngos = await _context.NGOs.ToListAsync();

                return View(ngos); 
            }
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Fund()
        {
            return View();
        }
        public IActionResult Organisation()
        {
            return View();
        }
       
    }
    
 }

