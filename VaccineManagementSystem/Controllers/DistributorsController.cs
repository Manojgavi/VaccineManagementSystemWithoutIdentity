using System.Data;
using System.Linq;
using System.Web.Mvc;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.ControllerService;
using System.Collections.Generic;
using VaccineManagementSystem.Proxy;
using System;
using System.Net.Mail;
using System.Net;

namespace VaccineManagementSystem.Controllers
{
    [Authorize(Roles ="Distributor")]
    public class DistributorsController : Controller
    {
        private readonly IDistributorControllerService distributorControllerService;
        private readonly IManufacturerProxy manufacturerProxy;
        public DistributorsController(IManufacturerProxy manufacturerProxy, IDistributorControllerService distributorControllerService)
        {
            this.manufacturerProxy = manufacturerProxy;
            this.distributorControllerService = distributorControllerService;
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            Distributor distributor = new Distributor();
            distributor=distributorControllerService.Create();
            return View(distributor);
        }
        [HttpPost]
        [AllowAnonymous]
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
                #region mail sending
                SendVerificationLinkEmail(distributor.Email,distributor.Name);
                #endregion
                return Content("Successfully Registered");
            }
            return View(distributor);
        }
        public ActionResult HospitalOrders()
        {
            List<OrdersFromHospitalVM> orders = new List<OrdersFromHospitalVM>();
            orders = distributorControllerService.HospitalOrders(Session["UserEmail"].ToString());
            return View(orders);
        }
        public ActionResult Delivered(int id)
        {
            distributorControllerService.UpdateHospitalOrdersById(id);
            return RedirectToAction("HospitalOrders");
        }
        
        public ActionResult OrdersByVaccineType()
        {
            List<CustomerOrdersViewModel> viewModel = new List<CustomerOrdersViewModel>();
            viewModel = distributorControllerService.GetHospitalOrdersViewModel(Session["UserEmail"].ToString());

            return View(viewModel);
        }
        public ActionResult Orders(int id,int count)
        {
            DistributorOrdersViewModel viewModel = new DistributorOrdersViewModel()
            {
                Count = count,
                Manufacturer = manufacturerProxy.GetManufacturersByVaccineId(id)
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Orders(DistributorOrdersViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    distributorControllerService.PostDistributorOrders(viewModel, Session["UserEmail"].ToString());
                    return RedirectToAction("OrdersByVaccineType");
                }
                catch (NullReferenceException)
                {

                    return RedirectToAction("Logout", "Accounts");
                }
            }

            return View(viewModel);
        }
        [NonAction]
        public void SendVerificationLinkEmail(string Email,string name)
        {
            var fromEmail = new MailAddress("greeshother@gmail.com");
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "othergreesh";
            string subject = "Distributor : Your account is successfully registered";

            string body = "Hi " + name + "<br/><br/>We are excited to tell you that your account is successfully registered as a distributor in our website. Please wait until one of our admin verify your details, you will recieve a mail after admins approval";

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
