using Wtt.Domain.Entities;
using Wtt.Domain.Entities.Enums;

namespace Wtt.DataAccess
{
    public interface IWttDataAccess
    {
        #region Employee
        public Task<Employee> SaveEmployeeAsync(Employee user);
        public Task<Employee> GetEmployeeAsync(int id);
        public Task<List<Employee>> GetEmployeesAsync(string name, Gender gender, int pageNumer, int pageSize);
        public System.Threading.Tasks.Task DeleteEmployee(Employee employee);
        public System.Threading.Tasks.Task UpdateEmployeeAsync(Employee employee);

        #endregion

        #region FoodReservation
        //public Task<FoodReservation> AddFoodReservationAsync(int Id);
        public Task<FoodReservation> SaveFoodReservationAsync(FoodReservation foodres);
        public System.Threading.Tasks.Task UpdateFoodReservationAsync(FoodReservation foodreservation);
        public System.Threading.Tasks.Task DeleteFoodReservation(FoodReservation foodreservation);
        public Task<FoodReservation> GetFoodReservationAsync(int Id);
        public Task<List<FoodReservation>> GetFoodReservationsAsync(int EmployeeId, DateTime ReservedDate, int pageNumber,int pageSize);
        #endregion

        #region Food
        //public Task<Food> AddFoodAsync(int Id);
        public Task<Food> SaveFoodAsync(Food f);
        public System.Threading.Tasks.Task UpdateFoodAsync(Food food);
        public System.Threading.Tasks.Task DeleteFoodAsync(Food food);
        public Task<Food> GetFoodAsync(int Id);
        public Task<List<Food>> GetFoodsAsync(string Name, int pageNumber, int pageSize);
        #endregion

        #region Mission
        //public Task<Mission> AddMission(int Id);
        public Task<Mission> SaveMissionAsync(Mission miss);
        public Task<Mission> GetMissionAsync(int Id);
        public System.Threading.Tasks.Task DeleteMissionAsync(Mission mission);
        public System.Threading.Tasks.Task UpdateMissionAsync(Mission mission);
        public Task<List<Mission>> GetMissionsAsync(DateTime Date,int EmployeeId,int ProjectId, int pageNumber, int pageSize);
        #endregion

        #region Presence
        //public Task<Presence> AddPresence(int Id);
        public Task<Presence> SavePresenceAsynce(Presence presence);
        public Task<Presence> GetPresenceAsync(int Id);
        //public System.Threading.Tasks.Task DeletePresenceAsync(Presence presence);
        public System.Threading.Tasks.Task UpdatePresenceAsync(Presence presence);
        public Task<List<Presence>> GetPresencesAsync(int EmployeeId, DateTime Starttime, DateTime Endtime, int pageNumber, int pageSize);
        #endregion

        #region Vacation
        //public Task<Vacation> AddVacation(int Id);
        public Task<Vacation> SaveVacationAsync(Vacation vacation);
        public Task<Vacation> GetVacationAsync(int Id);
        public Task<List<Vacation>> GetVacationsAsync(int EmployeeId, DateTime Date, VacationStatus Status, int pageNumber, int pageSize);
        public System.Threading.Tasks.Task UpdateVacationAsync(Vacation vacation);
        #endregion

        #region User
        public Task<User> SaveUserAsync(User user);
        public Task<User> GetUserAsync(string username);
        public Task<List<User>> GetUsersAsync(string username,int pageNumber, int pageSize);
        public System.Threading.Tasks.Task DeleteUserAsync(User user);
        public System.Threading.Tasks.Task UpdateUserAsync(User user);
        #endregion

        #region Task
        public  Task<Domain.Entities.Task> SaveTaskAsync(Domain.Entities.Task task);
        public  Task<Domain.Entities.Task> GetTaskAsync(int Id);
        public System.Threading.Tasks.Task UpdateTaskAsync(Domain.Entities.Task task);
        public Task<List<Domain.Entities.Task>> GetTasksAsync(int performedId, int EmployeeId, int pageNumber, int pageSize);

        //System.Threading.Tasks.Task SaveFoodReservationAsync(FoodReservation foodres);
        //System.Threading.Tasks.Task SaveMissionAsync(Mission miss);
        //System.Threading.Tasks.Task SaveVacationAsync(Vacation vac);

        #endregion

        #region Project
        //public Task<Project> AddProject(int Id);
        public Task<Project> SaveProjectAsync(Project project);
        public Task<Project> GetProjectAsync(int Id);
        public Task<List<Project>> GetProjectsAsync(string Name, int pageNumber, int pageSize);
        public System.Threading.Tasks.Task DeleteProjectAsync(Project project);
        public System.Threading.Tasks.Task UpdateProjectAsync(Project project);
        //System.Threading.Tasks.Task GetTaskAsync(int id);



        #endregion



    }
}

