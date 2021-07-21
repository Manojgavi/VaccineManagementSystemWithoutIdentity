using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineManagementSystemApi.Repository.Entity;

namespace VaccineManagementSystemApi.Repository
{
    public interface IOrdersRepository
    {
        void PlaceHospitalOrder(HospitalOrders hospitalOrders);

    }
}
