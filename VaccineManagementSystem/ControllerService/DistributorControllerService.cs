using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VaccineManagementSystem.Proxy;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.ControllerService
{
    public class DistributorControllerService : IDistributorControllerService
    {
        private readonly IDistributorProxy proxy;
        public DistributorControllerService(IDistributorProxy proxy)
        {
            this.proxy = proxy;
        }
        public Distributor Create()
        {
            Distributor distributor = new Distributor()
            {
                Locations = new SelectList(proxy.GetLocations())
            };
            return distributor;
        }

        public void PostDistributor(Distributor distributor)
        {
            Models.Distributor distributorModel = new Models.Distributor();
            distributorModel = AutoMapper.Mapper.Map<ViewModel.Distributor, Models.Distributor>(distributor);
            proxy.PostDistributor(distributorModel);
        }
    }
}