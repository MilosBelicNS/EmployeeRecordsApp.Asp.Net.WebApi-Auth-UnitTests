using EmployeeRecordsApp.Asp.NetWebApi.Interfaces;
using EmployeeRecordsApp.Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRecordsApp.Asp.NetWebApi.Repository
{
    public class TeamRepository : IDisposable, ITeamRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       public IEnumerable<Team> GetAll()
        {
            return db.Teams;
        }

        public IEnumerable<Team> Efficiency()
        {
            var teams = db.Teams.OrderByDescending(t => t.CompletedProjects);

            List<Team> result = new List<Team>();

            result.Add(teams.ToList()[0]);
            result.Add(teams.ToList()[1]);

             return result;

        }

        public IEnumerable<TeamDto> Abundance()
        {
            var teams = db.Employee.GroupBy(x => x.Team, x => x, (team, employee) => new TeamDto()
            //group employee from database by Teams
            {
                Team = team.Name,
                EmployeeNumber = employee.Count(),
            }).OrderBy(x => x.EmployeeNumber);

            List<TeamDto> result = new List<TeamDto>();

            result.Add(teams.ToList()[0]);
            result.Add(teams.ToList()[teams.Count()-1]);

            return result;

        }

        public Team GetById(int id)
        {
            return db.Teams.Find(id);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




    }
}