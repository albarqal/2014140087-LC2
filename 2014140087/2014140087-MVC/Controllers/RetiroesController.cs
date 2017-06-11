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
    public class RetiroesController : Controller
    {
        //private _2014140087DbContext db = new _2014140087DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public RetiroesController()
        {

        }

        public RetiroesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Retiroes
        public ActionResult Index()
        {
            return View(_UnityOfWork.Retiro.GetAll());
        }

        // GET: Retiroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // GET: Retiroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Retiroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RetiroId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Retiro.Add(retiro);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retiro);
        }

        // GET: Retiroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: Retiroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RetiroId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(retiro);
                //db.Entry(retiro).State = EntityState.Modified;
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retiro);
        }

        // GET: Retiroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: Retiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            _UnityOfWork.Retiro.Delete(retiro);
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
