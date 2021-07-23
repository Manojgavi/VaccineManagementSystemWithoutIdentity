using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
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
                #region mail sending
                SendVerificationLinkEmail(hospital.Email,hospital.HospitalName);
                #endregion
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
            List<CustomersDataViewModel> customers = new List<CustomersDataViewModel>();
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
        public ActionResult Orders(int id,int count)
        {
            HospitalOrdersViewModel hospitalOrdersViewModel = new HospitalOrdersViewModel();
            hospitalOrdersViewModel = hospitalControllerService.HospitalOrder();
            hospitalOrdersViewModel.VaccineTypeId = id;
            hospitalOrdersViewModel.Order = count;
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
        [NonAction]
        public void SendVerificationLinkEmail(string Email,string name)
        {
            var fromEmail = new MailAddress("greeshother@gmail.com");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "othergreesh";
            string subject = "Hospital : Your account is successfully registered";

            string body = "Hi, Representative of "+name+"<br/><br/>We are excited to tell you that your Hospital is succesfully registered in our website.Please wait until one of our admin verify your details, you will recieve a mail after admins approval";

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
