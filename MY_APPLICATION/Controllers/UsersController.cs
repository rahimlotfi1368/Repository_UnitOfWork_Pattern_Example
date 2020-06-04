using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace MY_APPLICATION.Controllers
{
    public partial class UsersController : Infrastracture.BaseController
    {

        public UsersController()
        {
            
        }

        [System.Web.Mvc.HttpGet]
        public virtual ActionResult Index()
        {
            var users = UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.Get(includeProperties:"Role");//MyDatabaseContext.Users.Include(c => c.Role);
            return View(users);
        }

        [System.Web.Mvc.HttpGet]
        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Models.User user =
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.GetById(id.Value); //db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [System.Web.Mvc.HttpGet]
        public virtual ActionResult Create()
        {
            var roles =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Get();
            ViewBag.RoleId = new SelectList(roles.ToList(), "Id", "Name");
            return View();
        }


        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "Id,RoleId,IsActive,Username,Password,FullName")] Models.User user)
        {
            if (ModelState.IsValid)
            {
                //user.Id = Guid.NewGuid();
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.Insert(user);
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.Save();
                return RedirectToAction(MVC.Users.Index());
            }

            var roles =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Get();
            ViewBag.RoleId = new SelectList(roles.ToList(), "Id", "Name", user.RoleId);
            return View(user);
        }

        [System.Web.Mvc.HttpGet]
        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Models.User user =
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.GetById(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }

            var roles =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Get();

            ViewBag.RoleId = new SelectList(roles.ToList(), "Id", "Name", user.RoleId);
            return View(user);
        }


        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Id,RoleId,IsActive,Username,Password,FullName")] Models.User user)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.Update(user);
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.Save();
                return RedirectToAction(MVC.Users.Index());
            }

            var roles =
                UnitOfWork.RoleUserManagerUnitOfWork.RoleRepository.Get();

            ViewBag.RoleId = new SelectList(roles, "Id", "Name", user.RoleId);
            return View(user);
        }

        [System.Web.Mvc.HttpGet]
        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Models.User user =
                UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.GetById(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Delete")]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.DeleteById(id);
            UnitOfWork.RoleUserManagerUnitOfWork.UserRepository.Save();
            return RedirectToAction(MVC.Users.Index());
        }
               
    }
}
