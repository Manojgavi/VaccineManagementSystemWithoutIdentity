using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.ControllerService;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

namespace VaccineManagementSystem.Controllers
{
    [Authorize(Roles ="Manufacturer")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerControllerService manufacturerControllerService;
        public ManufacturersController(IManufacturerControllerService manufacturerControllerService)
        {
            this.manufacturerControllerService = manufacturerControllerService;
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            Manufacturer manufacturer= manufacturerControllerService.Create();
            
            return View(manufacturer);
        }
        [HttpPost]
        [AllowAnonymous]
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
                #region mail sending
                SendVerificationLinkEmail(manufacturer.Email,manufacturer.Name);
                #endregion
                return Content("Successfully Registered");
            }
            return View();
        }
        public ActionResult DistributorOrders()
        {
            List<ManufacturerOrdersViewModel> viewModels = new List<ManufacturerOrdersViewModel>();
            viewModels= manufacturerControllerService.GetManufacturerOrders(Session["UserEmail"].ToString());

            return View(viewModels);
        }
        public ActionResult Delivered(int id)
        {
            manufacturerControllerService.UpdateDistributorOrderStatus(id);
            return RedirectToAction("DistributorOrders");
        }
        [NonAction]
        public void SendVerificationLinkEmail(string Email,string name)
        {
            var fromEmail = new MailAddress("greeshother@gmail.com");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "othergreesh";
            string subject = "Manufacturer : Your account is successfully registered";

            string body = "Hi "+name+"<br/><br/>We are excited to tell you that your manufacturing plant is successfully registered in our website.Please wait until one of our admin verify your details, you will recieve a mail after admins approval";

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
