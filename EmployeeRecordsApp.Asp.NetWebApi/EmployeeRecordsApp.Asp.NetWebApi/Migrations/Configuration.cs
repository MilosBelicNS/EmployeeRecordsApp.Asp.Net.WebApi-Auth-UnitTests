namespace EmployeeRecordsApp.Asp.NetWebApi.Migrations
{
    using EmployeeRecordsApp.Asp.NetWebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeRecordsApp.Asp.NetWebApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeRecordsApp.Asp.NetWebApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Teams.AddOrUpdate(
                new Team() { Name = "Develop", Founded = 2005, CompletedProjects = 33 },
                new Team() { Name = "Testing", Founded = 2006, CompletedProjects = 23 },
                new Team() { Name = "Management", Founded = 2004, CompletedProjects = 35 });
            context.SaveChanges();

            context.Employee.AddOrUpdate(
                new Employed() { Name = "Pera Peric", Role = "Test developer", Birth = 1980, EmploymentYear = 2008, Salary = 4000, TeamId = 2 },
                new Employed() { Name = "Mika Mikic", Role = "Software developer", Birth = 1994, EmploymentYear = 2006, Salary = 5000, TeamId = 1 },
                new Employed() { Name = "Zika Zikic", Role = "Manger", Birth = 1982, EmploymentYear = 2009, Salary = 4500, TeamId = 3 },
                new Employed() { Name = "Boba Bobic", Role = "Software developer", Birth = 1990, EmploymentYear = 2015, Salary = 6000, TeamId = 1 });

            context.SaveChanges();
        }
    }
}
