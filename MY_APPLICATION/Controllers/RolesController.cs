using System;
using System.Linq;
namespace MY_APPLICATION.Controllers
{
    public partial class RolesController : Infrastracture.BaseController
    {
        public RolesController():base()
        {
            
        }


        [System.Web.Mvc.HttpGet]
        public virtual System.Web.Mvc.ActionResult Index()
        {
            var allRoles =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Get();

            return View(allRoles.ToList());
        }

        [System.Web.Mvc.HttpGet]
        public virtual System.Web.Mvc.ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var role =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.GetById(id.Value);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [System.Web.Mvc.HttpGet]
        public virtual System.Web.Mvc.ActionResult Create()
        {
            return View();
        }

        
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public virtual System.Web.Mvc.ActionResult Create([System.Web.Mvc.Bind(Include = "Id,Name,IsActive")] Models.Role role)
        {
            if (ModelState.IsValid)
            {
                //role.Id = Guid.NewGuid();
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Insert(role);
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Save();
                return RedirectToAction(MVC.Roles.Index());
            }

            return View(role);
        }

        [System.Web.Mvc.HttpGet]
        public virtual System.Web.Mvc.ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var role =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.GetById(id.Value);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public virtual System.Web.Mvc.ActionResult Edit([System.Web.Mvc.Bind(Include = "Id,Name,IsActive")] Models.Role role)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Insert(role);
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Save();
                return RedirectToAction(MVC.Roles.Index());
            }
            return View(role);
        }

        [System.Web.Mvc.HttpGet]
        public virtual System.Web.Mvc.ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var role =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.GetById(id.Value);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Delete")]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public virtual System.Web.Mvc.ActionResult DeleteConfirmed(Guid id)
        {
            UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.DeleteById(id);
            UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Save();
            return RedirectToAction(MVC.Roles.Index());
        }

        
    }
}
