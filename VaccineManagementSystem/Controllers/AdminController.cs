using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                #region mail sending
                SendVerificationLinkEmail(registerViewModel.Email);
                #endregion

                return RedirectToAction("Index", "Admin");
            }
            return View(registerViewModel);
        }
        public ActionResult DeleteHospital(int id)
        {
            Hospital hospital = new Hospital();
            hospital = adminControllerService.GetHospitalById(id);
            return View(hospital);
        }
        [HttpPost]

        public ActionResult DeleteHospital(Hospital hospital)
        {
            
                adminControllerService.DeleteHospitalById(hospital.Id);

                return RedirectToAction("Index", "Admin");
            
        }
        public ActionResult DeleteDistributor(int id)
        {
            Distributor distributor = new Distributor();
            distributor = adminControllerService.GetDistributorById(id);
            return View(distributor);
        }
        [HttpPost]

        public ActionResult DeleteDistributor(Distributor distributor)
        {

            adminControllerService.DeleteDistributorById(distributor.Id);

            return RedirectToAction("Index", "Admin");

        }
        public ActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer = adminControllerService.GetManufacturerById(id);
            return View(manufacturer);
        }
        [HttpPost]

        public ActionResult DeleteManufacturer(Manufacturer manufacturer)
        {

            adminControllerService.DeleteManufacturerById(manufacturer.Id);

            return RedirectToAction("Index", "Admin");

        }
        public ActionResult Users()
        {
            List<Models.User> users = new List<Models.User>();
            users=accountControllerService.GetUsers();
            return View(users);
        }
        public ActionResult DeleteUsers(int id)
        {
            accountControllerService.DeleteUserById(id);
            return RedirectToAction("Users");
        }
        [NonAction]
        public void SendVerificationLinkEmail(string Email)
        {
            var fromEmail = new MailAddress("greeshother@gmail.com");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "othergreesh";
            string subject = "Your account has been activated";

            string body = "<br/><br/>We are excited to tell you that your account is successfully created in our website. You can now login with the credentials given while registering";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

                smtp.Send(message);

        }
    }
}