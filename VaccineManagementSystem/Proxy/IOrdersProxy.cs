using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaccineManagementSystem.Models;
namespace VaccineManagementSystem.Proxy
{
    public interface IOrdersProxy
    {
        void PlaceHospitalOrder(HospitalOrders hospitalOrders);
    }
}