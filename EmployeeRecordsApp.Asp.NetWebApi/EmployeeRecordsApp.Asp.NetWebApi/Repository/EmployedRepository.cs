using EmployeeRecordsApp.Asp.NetWebApi.Interfaces;
using EmployeeRecordsApp.Asp.NetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EmployeeRecordsApp.Asp.NetWebApi.Repository
{
    public class EmployedRepository :IDisposable, IEmployedRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Employed> GetAll()
        {
            return db.Employee.Include(e => e.Team);
        }

        public IEnumerable<Employed> GetByBirth(int associated)
        {
            var employee = db.Employee.Where(e => e.EmploymentYear > associated).OrderBy(e => e.EmploymentYear);

            return employee;
        }

        public IEnumerable<Employed> Search(Filter filter)
        {

            var employee = db.Employee.Include(e => e.Team).Where(e => e.Birth >= filter.Min & e.Birth <= filter.Max).OrderBy(e => e.Birth);
            return employee;
        }

        public Employed GetById(int id)
        {
            return db.Employee.Find(id);
        }

        public void Create(Employed employed)
        {
            db.Employee.Add(employed);
            db.SaveChanges();
        }


        public void Delete(Employed employed)
        {
            db.Employee.Remove(employed);
            db.SaveChanges();
        }

        public void Update(Employed employed)
        {
            db.Entry(employed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }catch(DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(db != null)
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