using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    public class VaccineTypesController : Controller
    {
        private readonly IVaccineTypeControllerService controllerService;
        public VaccineTypesController(IVaccineTypeControllerService controllerService)
        {
            this.controllerService = controllerService;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VaccineType vaccineType)
        {
            if(ModelState.IsValid)
            {
                controllerService.PostVaccineType(vaccineType);
                RedirectToAction("Index", "Home");
            }
            return View();
        }
       
    }
}
