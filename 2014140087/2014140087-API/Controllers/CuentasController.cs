using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _2014140087_ENT;
using _2014140087_PER;
using _2014140087_ENT.IRepositories;

namespace _2014140087_API.Controllers
{
    public class CuentasController : ApiController
    {
        //private _2014140087DbContext db = new _2014140087DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public CuentasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        /* // GET: api/Cuentas
         public IQueryable<Cuenta> GetCuenta()
         {
             return _UnityOfWork.Cuenta;
         }*/
        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var cuentas = _UnityOfWork.Cuenta.GetAll();

            if (cuentas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(cuentas);
        }



        // GET: api/Cuentas/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult GetCuenta(int id)
        {
            Cuenta cuenta = _UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        // PUT: api/Cuentas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuenta(int id, Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta.Pin)
            {
                return BadRequest();
            }

            //db.Entry(cuenta).State = EntityState.Modified;
            _UnityOfWork.StateModified(cuenta);
            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        /*
        // POST: api/Cuentas
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult PostCuenta(Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuenta.Add(cuenta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuenta.Pin }, cuenta);
        }
        */
        [HttpPost]
        public IHttpActionResult Create(Cuenta Cuentas)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var floreria = Mapper.Map<FloreriaDto, Florerias>(floreriaDTO);

            _UnityOfWork.Cuenta.Add(Cuentas);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CuentaExists(Cuentas.NumeroCuenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Cuentas.NumeroCuenta}, Cuentas);
        }




        // DELETE: api/Cuentas/5
        [ResponseType(typeof(Cuenta))]
        public IHttpActionResult DeleteCuenta(int id)
        {
            Cuenta cuenta = _UnityOfWork.Cuenta.Get(id);
            if (cuenta == null)
            {
                return NotFound();
            }


            _UnityOfWork.Cuenta.Remove(cuenta);
            _UnityOfWork.SaveChanges();


            return Ok(cuenta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuentaExists(int id)
        {
            return _UnityOfWork.Cuenta.GetEntity().Count(e => e.NumeroCuenta== id) > 0;
        }
    }
}