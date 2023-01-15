using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wtt.DataAccess.DbContexts;
using Wtt.Domain.Entities;
using Wtt.Domain.Entities.Enums;

namespace Wtt.DataAccess
{
    public class WttDataAccess : IWttDataAccess
    {
        private readonly WttDbContext _wttDbContext;

        public WttDataAccess(WttDbContext wttDbContext)
        {
            _wttDbContext = wttDbContext;
        }

        #region Employee

        public async System.Threading.Tasks.Task DeleteEmployee(Employee employee)
        {
            _wttDbContext.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _wttDbContext.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployeesAsync(string name, Gender gender, int pageNumer, int pageSize)
        {
            return await _wttDbContext.Employees.Where(e => e.Fullname.Contains(name) && e.Gender == gender).Skip((pageNumer - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Employee> SaveEmployeeAsync(Employee employee)
        {
            await _wttDbContext.Employees.AddAsync(employee);
            await _wttDbContext.SaveChangesAsync();
            return employee;
        }

        public async System.Threading.Tasks.Task UpdateEmployeeAsync(Employee employee)
        {
            _wttDbContext.Employees.Update(employee);
            await _wttDbContext.SaveChangesAsync();
        }
        #endregion

        #region FoodReservation

        public async Task<FoodReservation> SaveFoodReservationAsync(FoodReservation foodres)
        {
            await _wttDbContext.FoodReserVations.AddAsync(foodres);
            await _wttDbContext.SaveChangesAsync();
            return foodres;
        }

        public async System.Threading.Tasks.Task UpdateFoodReservationAsync(FoodReservation foodreservation)
        {
            _wttDbContext.FoodReserVations.Update(foodreservation);
            await _wttDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteFoodReservation(FoodReservation foodreservation)
        {
            _wttDbContext.FoodReserVations.Remove(foodreservation);
        }

        public async Task<FoodReservation> GetFoodReservationAsync(int Id)
        {
            return await _wttDbContext.FoodReserVations.FindAsync(Id);
        }

        public async Task<List<FoodReservation>> GetFoodReservationsAsync(int EmployeeId, DateTime ReservedDate, int pageNumber, int pageSize)
        {
            return await _wttDbContext.FoodReserVations.Where(fr => fr.EmployeeId == EmployeeId && fr.ReservedDate == ReservedDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        #endregion

        #region Food


        public async System.Threading.Tasks.Task<Food> SaveFoodAsync(Food f)
        {
            await _wttDbContext.Foods.AddAsync(f);
            await _wttDbContext.SaveChangesAsync();
            return f;
        }

        public async System.Threading.Tasks.Task UpdateFoodAsync(Food food)
        {
            _wttDbContext.Foods.Update(food);
            await _wttDbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteFoodAsync(Food food)
        {
            _wttDbContext.Foods.Remove(food);
        }

        public async Task<Food> GetFoodAsync(int Id)
        {
            return await _wttDbContext.Foods.FindAsync(Id);
        }

        public async Task<List<Food>> GetFoodsAsync(string Name, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Foods.Where(f => f.Name == Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion

        #region Mission


        public async Task<Mission> SaveMissionAsync(Mission miss)
        {
            await _wttDbContext.Missions.AddAsync(miss);
            await _wttDbContext.SaveChangesAsync();
            return miss;
        }

        public async Task<Mission> GetMissionAsync(int Id)
        {
            return await _wttDbContext.Missions.FindAsync(Id);
        }

        public async System.Threading.Tasks.Task DeleteMissionAsync(Mission mission)
        {
            _wttDbContext.Missions.Remove(mission);
        }

        public async System.Threading.Tasks.Task UpdateMissionAsync(Mission mission)
        {
            _wttDbContext.Missions.Update(mission);
            await _wttDbContext.SaveChangesAsync();
        }

        public async Task<List<Mission>> GetMissionsAsync(DateTime Date, int EmployeeId, int ProjectId, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Missions.Where(m => m.Date == Date && m.ProjectId == ProjectId && m.EmployeeId == EmployeeId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion

        #region Presence


        public async Task<Presence> SavePresenceAsynce(Presence presence)
        {
            await _wttDbContext.Presences.AddAsync(presence);
            await _wttDbContext.SaveChangesAsync();
            return presence;
        }

        public async Task<Presence> GetPresenceAsync(int Id)
        {
            return await _wttDbContext.Presences.FindAsync(Id);
        }

        public async System.Threading.Tasks.Task UpdatePresenceAsync(Presence presence)
        {
            _wttDbContext.Presences.Update(presence);
            await _wttDbContext.SaveChangesAsync();
        }

        public async Task<List<Presence>> GetPresencesAsync(int EmployeeId, DateTime Starttime, DateTime Endtime, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Presences.Where(p => p.EmployeeId == EmployeeId && p.Starttime == Starttime && p.Endtime == Endtime).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion

        #region Vacation


        public async Task<Vacation> SaveVacationAsync(Vacation vacation)
        {
            await _wttDbContext.Vacations.AddAsync(vacation);
            await _wttDbContext.SaveChangesAsync();
            return vacation;
        }

        public async Task<Vacation> GetVacationAsync(int Id)
        {
            return await _wttDbContext.Vacations.FindAsync(Id);
        }

        public async Task<List<Vacation>> GetVacationsAsync(int EmployeeId, DateTime Date, VacationStatus Status, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Vacations.Where(v => v.EmployeeId == EmployeeId && v.Date == Date && v.Status == Status).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateVacationAsync(Vacation vacation)
        {
            _wttDbContext.Vacations.Update(vacation);
            await _wttDbContext.SaveChangesAsync();
        }
        #endregion

        #region User
        public async Task<User> SaveUserAsync(User user)
        {
            await _wttDbContext.Users.AddAsync(user);
            await _wttDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _wttDbContext.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync(string username, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Users.Where(u => u.Username == username).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(User user)
        {
            _wttDbContext.Users.Remove(user);
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            _wttDbContext.Users.Update(user);
            await _wttDbContext.SaveChangesAsync();
        }
        #endregion

        #region Task
        public async Task<Domain.Entities.Task> SaveTaskAsync(Domain.Entities.Task task)
        {
            await _wttDbContext.Tasks.AddAsync(task);
            return task;
        }
        public async Task<Domain.Entities.Task> GetTaskAsync(int Id)
        {
            return await _wttDbContext.Tasks.FindAsync(Id);
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(Domain.Entities.Task task)
        {
            _wttDbContext.Tasks.Update(task);
            await _wttDbContext.SaveChangesAsync();
        }

        public async Task<List<Domain.Entities.Task>> GetTasksAsync(int performedId, int EmployeeId, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Tasks.Where(t => t.EmployeeId == EmployeeId && t.EmployeeId == EmployeeId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        #endregion

        #region Project


        public async Task<Project> SaveProjectAsync(Project project)
        {
            await _wttDbContext.Projects.AddAsync(project);
            await _wttDbContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> GetProjectAsync(int Id)
        {
            return await _wttDbContext.Projects.FindAsync(Id);
        }

        public async Task<List<Project>> GetProjectsAsync(string Name, int pageNumber, int pageSize)
        {
            return await _wttDbContext.Projects.Where(p => p.Name == Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async System.Threading.Tasks.Task DeleteProjectAsync(Project project)
        {
            _wttDbContext.Projects.Remove(project);
        }

        public async  System.Threading.Tasks.Task UpdateProjectAsync(Project project)
        {
            _wttDbContext.Projects.Update(project);
            await _wttDbContext.SaveChangesAsync();
        }
        #endregion
    }
}
