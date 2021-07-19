using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;
using VaccineManagementSystem.Proxy;
using System.Web.Security;



namespace VaccineManagementSystem.Controllers
{
   
    public class AccountsController : Controller
    {
        private readonly IAccountControllerService accountControllerService;
        
        public AccountsController(IAccountControllerService accountControllerService)
        {
            this.accountControllerService = accountControllerService;
            
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                if (accountControllerService.Login(loginViewModel))
                {
                    FormsAuthentication.SetAuthCookie(loginViewModel.Email, false);
                    Session["UserEmail"] = loginViewModel.Email;
                    return RedirectToAction("Redirect");
                }
                return View(loginViewModel);
            }
            
            return View(loginViewModel);
        }
        //[Authorize(Roles="Admin")]
        //public ActionResult Register()
        //{
        //    RegisterViewModel registerViewModel = new RegisterViewModel();
        //    registerViewModel=accountControllerService.Register();
        //    return View(registerViewModel);
        //}
        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Register(RegisterViewModel registerViewModel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        accountControllerService.PostUSer(registerViewModel);
                
        //        return RedirectToAction("Index","Admin");
        //    }
        //    return View(registerViewModel);
        //}
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Redirect()
        {
            string userEmail = Session["UserEmail"].ToString();
            WebRoleProvider roleProvider = new WebRoleProvider();
            if (roleProvider.IsUserInRole(userEmail,"Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (roleProvider.IsUserInRole(userEmail, "Hospital"))
            {
                return RedirectToAction("Create", "Hospitals");
            }
            else if (roleProvider.IsUserInRole(userEmail, "Distributor"))
            {
                return RedirectToAction("Create", "Distributors");
            }
            else if (roleProvider.IsUserInRole(userEmail, "Manufacturer"))
            {
                return RedirectToAction("Create", "Manufacturers");
            }

            return Content("Sorry");

        }

    }
}