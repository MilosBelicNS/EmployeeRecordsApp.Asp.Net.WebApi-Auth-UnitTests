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
    public class TeamsController : ApiController
    {
        public ITeamRepository _repository { get; set; }

        public TeamsController(ITeamRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Team> GetAll()
        {
            return _repository.GetAll();
        }

        [Authorize]
        [Route("api/Efficiency")]
        public IEnumerable<Team> Efficiency()
        {
            return _repository.Efficiency();
        }

        [Authorize]
        [Route("api/Abundance")]
        public IEnumerable<TeamDto> Abundance()
        {
            return _repository.Abundance();
        }
        [Authorize]
        [ResponseType(typeof(Team))]
        public IHttpActionResult GetById(int id)
        {
            var team = _repository.GetById(id);
            
            if(team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
    }
}
