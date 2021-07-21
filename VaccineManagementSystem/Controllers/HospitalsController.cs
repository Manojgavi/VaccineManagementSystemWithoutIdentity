using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    [Authorize(Roles = "Hospital")]
    public class HospitalsController : Controller
    {
        private readonly IHospitalControllerService hospitalControllerService;
        public HospitalsController(IHospitalControllerService hospitalControllerService)
        {
            this.hospitalControllerService = hospitalControllerService;
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
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
        public ActionResult CustomerOrders()
        {
            List<CustomerOrdersViewModel> customerOrders = new List<CustomerOrdersViewModel>();
            try
            {
                customerOrders = hospitalControllerService.GetCustomerOrdersViewModel(Session["UserEmail"].ToString());
                return View(customerOrders);

            }
            catch(NullReferenceException)
            {

                return RedirectToAction("Logout", "Accounts");
            }
            
        }
        public ActionResult UpdateStatus()
        {
            List<Models.Customer> customers = new List<Models.Customer>();
            try
            {
                customers = hospitalControllerService.GetCustomersForHospital(Session["UserEmail"].ToString());
                return View(customers);

            }
             catch (NullReferenceException)
            {

                return RedirectToAction("Logout", "Accounts");
            }
            
        }
        public ActionResult Orders(int id)
        {
            HospitalOrdersViewModel hospitalOrdersViewModel = new HospitalOrdersViewModel();
            hospitalOrdersViewModel = hospitalControllerService.HospitalOrder();
            hospitalOrdersViewModel.VaccineTypeId = id;
            return View(hospitalOrdersViewModel);
        }
        [HttpPost]
        public ActionResult Orders(HospitalOrdersViewModel hospital)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    hospitalControllerService.PostHospitalOrders(hospital, Session["UserEmail"].ToString());
                    return RedirectToAction("CustomerOrders");
                }
                catch (NullReferenceException)
                {

                    return RedirectToAction("Logout", "Accounts");
                }

            }
            return View(hospital);
        }
        public ActionResult Vaccinated(int id)
        {
            hospitalControllerService.Vaccinated(id, 1);
            return RedirectToAction("UpdateStatus");
        }
        public ActionResult NotShownUp(int id)
        {
            hospitalControllerService.Vaccinated(id, 2);
            return RedirectToAction("UpdateStatus");
        }
    }
}
