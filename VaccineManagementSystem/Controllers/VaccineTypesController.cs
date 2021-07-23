using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VaccineManagementSystem.ControllerService;
using VaccineManagementSystem.ViewModel;

namespace VaccineManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VaccineTypesController : Controller
    {
        private readonly IVaccineTypeControllerService controllerService;
        public VaccineTypesController(IVaccineTypeControllerService controllerService)
        {
            this.controllerService = controllerService;
        }
        public ActionResult Index()
        {
            List<VaccineType> vaccineTypes = new List<VaccineType>();
            vaccineTypes = controllerService.GetVaccineTypes();
            return View(vaccineTypes);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VaccineType vaccineType)
        {
            if(ModelState.IsValid)
            {
                controllerService.PostVaccineType(vaccineType);
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineType vaccineType = controllerService.GetVaccineTypeById(id);
            if (vaccineType == null)
            {
                return HttpNotFound();
            }
            return View(vaccineType);
        }

        // POST: VaccineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            controllerService.DeleteVaccineTypeById(id);

            return RedirectToAction("Index");
        }

    }
}
