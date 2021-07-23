using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerControllerService controllerService;
        private readonly IHospitalProxy hospitalProxy;
        public CustomersController(IHospitalProxy hospitalProxy,ICustomerControllerService controllerService)
        {
            this.hospitalProxy = hospitalProxy;
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
                try
                {
                    controllerService.PostCustomer(customer);
                    Models.Hospital hospital = new Models.Hospital();
                    hospital = hospitalProxy.GetHospitalById(customer.HospitalId);
                    #region mail sending
                    SendVerificationLinkEmail(customer.Email,hospital.StartTime,hospital.EndTime,hospital.PhoneNumber,customer.Name);
                    #endregion
                    return Content("Successfully Registered");
                }
                //controllerService.PostCustomer(customer);
                //return Content("Successfully Registered");
                catch(ArgumentNullException)
                {
                    return HttpNotFound();
                }
            }
            Customer customer1 = controllerService.Create();
            return View(customer1);
        }
        [NonAction]
        public void SendVerificationLinkEmail(string Email,string start,string end,string phone,string name)
        {
            var fromEmail = new MailAddress("greeshother@gmail.com");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "othergreesh";
            string subject = "You are successfully registered for Vaccination";

            string body = "Hi "+name+"<br/><br/>We are excited to tell you that you are successfully registered in our website for vaccination. You can visit Hospital between "+start+" AM and "+end+" PM, You can Contact Hospital on :"+phone;

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
