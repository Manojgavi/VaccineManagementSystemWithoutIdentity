using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public interface IDistributorControllerService
    {
        Distributor Create();
        void PostDistributor(Distributor distributor);
    }
}