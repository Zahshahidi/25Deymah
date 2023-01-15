using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts
{
    public class WttDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<Food> Foods  { get; set; }
        public DbSet<FoodReservation> FoodReserVations { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Presence> Presences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public WttDbContext()
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(WttDbContext)));
            //base.OnModelCreating(modelBuilder);
        }



    }
}
