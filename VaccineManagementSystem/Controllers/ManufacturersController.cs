using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.ControllerService;
namespace VaccineManagementSystem.Controllers
{

    public class ManufacturersController : Controller
    {
        private readonly IManufacturerControllerService controllerService;
        public ManufacturersController(IManufacturerControllerService controlService)
        {
            this.controllerService = controlService;
        }
        public ActionResult Create()
        {
            Manufacturer manufacturer=controllerService.Create();
            return View(manufacturer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                controllerService.PostManufacturer(manufacturer);
                return Content("Successfully Registered");
            }
            return View();
        }
    }
}
