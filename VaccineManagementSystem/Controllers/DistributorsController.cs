using System.Data;
using System.Linq;
using System.Web.Mvc;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.ControllerService;

namespace VaccineManagementSystem.Controllers
{
    public class DistributorsController : Controller
    {
        private readonly IDistributorControllerService distributorControllerService;
        public DistributorsController(IDistributorControllerService distributorControllerService)
        {
            this.distributorControllerService = distributorControllerService;
        }
        public ActionResult Create()
        {
            Distributor distributor = new Distributor();
            distributor=distributorControllerService.Create();
            return View(distributor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Distributor distributor)
        {
            
            if(ModelState.IsValid)
            {
                if(distributorControllerService.IsInDb(distributor.Email))
                {
                    return Content("Email already registered");
                }
                distributorControllerService.PostDistributor(distributor);
                return Content("Successfully Registered");
            }
            return View(distributor);
        }

    }
}
