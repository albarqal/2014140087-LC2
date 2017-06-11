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
    public class RetiroesController : ApiController
    {
        //private _2014140087DbContext db = new _2014140087DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public RetiroesController(IUnityOfWork unityOfWork)
        {
            
                _UnityOfWork = unityOfWork;
            
        }

        /*

        // GET: api/Retiroes
        public IQueryable<Retiro> GetRetiro()
        {
            return db.Retiro;
        }
        */


        [HttpGet]
        public IHttpActionResult Get()
        {
            //La capa de persistencia no debe ser modificada, porque es única para todo canal de atencion de la aplicacion
            //por lo tanto, a nivel de controlador se debe de hacer las modificaciones.
            var cuentas = _UnityOfWork.Retiro.GetAll();

            if (cuentas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);



            return Ok(cuentas);
        }


        // GET: api/Retiroes/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult GetRetiro(int id)
        {
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return NotFound();
            }

            return Ok(retiro);
        }

        // PUT: api/Retiroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRetiro(int id, Retiro retiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retiro.RetiroId)
            {
                return BadRequest();
            }

            _UnityOfWork.StateModified(retiro);


            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetiroExists(id))
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

        /* // POST: api/Retiroes
         [ResponseType(typeof(Retiro))]
         public IHttpActionResult PostRetiro(Retiro retiro)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             db.Retiro.Add(retiro);
             db.SaveChanges();

             return CreatedAtRoute("DefaultApi", new { id = retiro.RetiroId }, retiro);
         }
         */

        [HttpPost]
        public IHttpActionResult Create(Retiro Retiro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //var floreria = Mapper.Map<FloreriaDto, Florerias>(floreriaDTO);

            _UnityOfWork.Retiro.Add(Retiro);

            try
            {
                _UnityOfWork.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RetiroExists(Retiro.RetiroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = Retiro.RetiroId }, Retiro);
        }


        // DELETE: api/Retiroes/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult DeleteRetiro(int id)
        {
            Retiro retiro = _UnityOfWork.Retiro.Get(id);
            if (retiro == null)
            {
                return NotFound();
            }

            _UnityOfWork.Retiro.Remove(retiro);
            _UnityOfWork.SaveChanges();

            return Ok(retiro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RetiroExists(int id)
        {
            return _UnityOfWork.Retiro.GetEntity().Count(e => e.RetiroId == id) > 0;
        }
    }
}