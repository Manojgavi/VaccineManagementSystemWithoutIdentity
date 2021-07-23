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
        bool IsInDb(string email);
        List<OrdersFromHospitalVM> HospitalOrders(string email);
        void UpdateHospitalOrdersById(int id);
        List<CustomerOrdersViewModel> GetHospitalOrdersViewModel(string email);
        void PostDistributorOrders(DistributorOrdersViewModel viewModel, string v);
    }
}