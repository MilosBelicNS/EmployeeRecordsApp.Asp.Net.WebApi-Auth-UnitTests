using EmployeeRecordsApp.Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordsApp.Asp.NetWebApi.Interfaces
{
   public  interface ITeamRepository
    {

        IEnumerable<Team> GetAll();
        IEnumerable<Team> Efficiency();
        IEnumerable<TeamDto> Abundance();
        Team GetById(int id);
    }
}
