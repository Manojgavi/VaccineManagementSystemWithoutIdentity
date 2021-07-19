using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;




namespace VaccineManagementSystem.ControllerService
{
    public interface IAccountControllerService
    {
        ViewModel.RegisterViewModel Register();
       bool Login(ViewModel.LoginViewModel loginViewModel);
        void PostUSer(ViewModel.RegisterViewModel registerViewModel);
    }
}