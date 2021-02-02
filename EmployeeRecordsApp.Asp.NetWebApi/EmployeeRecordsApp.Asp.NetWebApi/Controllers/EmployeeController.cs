using EmployeeRecordsApp.Asp.NetWebApi.Interfaces;
using EmployeeRecordsApp.Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace EmployeeRecordsApp.Asp.NetWebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        public IEmployedRepository _repository { get; set; }

        public EmployeeController(IEmployedRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employed> GetAll()
        {
            return _repository.GetAll();
        }
        [Authorize]
         public IEnumerable<Employed> GetByBirth(int associated)
        {
            return _repository.GetByBirth(associated);
        }
        [Authorize]
        [Route("api/Search")]
        public IEnumerable<Employed> Search(Filter filter)
        {
            return _repository.Search(filter);
        }

        [Authorize]
        [ResponseType(typeof(Employed))]
        public IHttpActionResult GetById(int id)
        {
            var employed = _repository.GetById(id);

            if(employed == null)
            {
                return NotFound();
            }

            return Ok(employed);
        }
        [Authorize]
        [ResponseType(typeof(Employed))]
        public IHttpActionResult Delete(int id)
        {
            var employed = _repository.GetById(id);

            if(employed == null)
            {
                return NotFound();
            }

            _repository.Delete(employed);
            return Ok();
        }

        [Authorize]
        [ResponseType(typeof(Employed))]
        public IHttpActionResult Post(Employed employed)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Create(employed);
            return CreatedAtRoute("DefaultApi", new { Id = employed.Id }, employed);
        }

        [Authorize]
        [ResponseType(typeof(Employed))]
        public IHttpActionResult Put(int id, Employed employed)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(employed.Id != id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(employed);
            }
            catch
            {
                return Conflict();
            }
            return Ok(employed);
        }

    }
}
