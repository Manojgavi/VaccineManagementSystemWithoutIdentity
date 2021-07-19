using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminControllerService adminControllerService;
        private readonly IAccountControllerService accountControllerService;
        public AdminController(IAdminControllerService adminControllerService, IAccountControllerService accountControllerService)
        {
            this.adminControllerService = adminControllerService;
            this.accountControllerService = accountControllerService;
        }
        // GET: Admin
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Distributors()
        {
            List<Distributor> distributors = new List<Distributor>();
            distributors=adminControllerService.GetDistributors();
            return View(distributors);
        }
        public ActionResult Manufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            manufacturers = adminControllerService.GetManufacturers();
            return View(manufacturers);
        }
        public ActionResult Hospitals()
        {
            List<Hospital> hospitals = new List<Hospital>();
            hospitals = adminControllerService.GetHospitals();
            return View(hospitals);
        }
        public ActionResult ApproveDistributor(int id)
        {
            RegisterViewModel user = new RegisterViewModel();
            user = adminControllerService.UserFromDistributor(id);
            return View("Register",user);
        }
        [HttpPost]
        
        public ActionResult ApproveDistributor(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                accountControllerService.PostUSer(registerViewModel);

                return RedirectToAction("Index", "Admin");
            }
            return View(registerViewModel);
        }
        public ActionResult ApproveManufacturer(int id)
        {
            RegisterViewModel user = new RegisterViewModel();
            user = adminControllerService.UserFromManufacturer(id);
            return View("Register", user);
        }
        [HttpPost]
        
        public ActionResult ApproveManufacturer(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                accountControllerService.PostUSer(registerViewModel);

                return RedirectToAction("Index", "Admin");
            }
            return View(registerViewModel);
        }

        public ActionResult ApproveHospital(int id)
        {
            RegisterViewModel user = new RegisterViewModel();
            user = adminControllerService.UserFromHospital(id);
            return View("Register", user );
        }
        [HttpPost]

        public ActionResult ApproveHospital(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                accountControllerService.PostUSer(registerViewModel);

                return RedirectToAction("Index", "Admin");
            }
            return View(registerViewModel);
        }
        public ActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel = accountControllerService.Register();
            return View(registerViewModel);
            //return View();
        }
        [HttpPost]
        
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                accountControllerService.PostUSer(registerViewModel);

                return RedirectToAction("Index", "Admin");
            }
            return View(registerViewModel);
        }
    }
}