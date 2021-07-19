using System.Linq;
using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerControllerService controllerService;
        public CustomersController(ICustomerControllerService controllerService)
        {
            this.controllerService = controllerService;
        }
        public ActionResult Create()
        {
            Customer customer=controllerService.Create();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                controllerService.PostCustomer(customer);
                return Content("Successfully Registered");
            }
            return View(customer);
        }
    }
}
