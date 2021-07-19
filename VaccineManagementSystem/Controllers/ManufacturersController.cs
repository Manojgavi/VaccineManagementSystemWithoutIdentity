using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.ControllerService;
namespace VaccineManagementSystem.Controllers
{

    public class ManufacturersController : Controller
    {
        private readonly IManufacturerControllerService manufacturerControllerService;
        public ManufacturersController(IManufacturerControllerService manufacturerControllerService)
        {
            this.manufacturerControllerService = manufacturerControllerService;
        }
        public ActionResult Create()
        {
            Manufacturer manufacturer= manufacturerControllerService.Create();
            return View(manufacturer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                if (manufacturerControllerService.IsInDb(manufacturer.Email))
                {
                    return Content("Email already registered");
                }
                manufacturerControllerService.PostManufacturer(manufacturer);
                return Content("Successfully Registered");
            }
            return View();
        }
    }
}
