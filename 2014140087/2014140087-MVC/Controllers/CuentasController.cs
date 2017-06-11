using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2014140087_ENT;
using _2014140087_PER;
using _2014140087_ENT.IRepositories;

namespace _2014140087_MVC.Controllers
{
    public class CuentasController : Controller
    {
        //private _2014140087DbContext db = new _2014140087DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public CuentasController()
        {

        }
        public CuentasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Cuentas
        public ActionResult Index()
        {
            return View(_UnityOfWork.Cuenta.GetAll());
        }

        // GET: Cuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = _UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pin,NumeroCuenta")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                // db.Cuenta.Add(cuenta);
                _UnityOfWork.Cuenta.Add(cuenta);
                _UnityOfWork.SaveChanges();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cuenta);
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta = _UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: Cuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pin,NumeroCuenta")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(cuenta).State = EntityState.Modified;
                //db.SaveChanges();
                _UnityOfWork.StateModified(cuenta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuenta);
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuenta cuenta =_UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return HttpNotFound();
            }
            return View(cuenta);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuenta cuenta = _UnityOfWork.Cuenta.Get(id);
            _UnityOfWork.Cuenta.Delete(cuenta);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
