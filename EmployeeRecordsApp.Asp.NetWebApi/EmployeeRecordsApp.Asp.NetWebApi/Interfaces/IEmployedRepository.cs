using EmployeeRecordsApp.Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecordsApp.Asp.NetWebApi.Interfaces
{
   public  interface IEmployedRepository
    {
        IEnumerable<Employed> GetAll();
        IEnumerable<Employed> GetByBirth();
        IEnumerable<Employed> Search(Filter filter);
        Employed GetById(int id);
        void Create(Employed employed);
        void Delete(Employed employed);
        void Update(Employed employed);




    }
}
