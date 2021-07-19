using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly IHospitalControllerService hospitalControllerService;
        public HospitalsController(IHospitalControllerService hospitalControllerService)
        {
            this.hospitalControllerService = hospitalControllerService;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hospital hospital)
        {
            if(ModelState.IsValid)
            {
                if (hospitalControllerService.IsInDb(hospital.Email))
                {
                    return Content("Email already registered");
                }
                hospitalControllerService.PostHospital(hospital);
                return Content("Succesfully registered");
            }
            return View(hospital);
        }
    }
}
