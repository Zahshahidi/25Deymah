using Wtt.Domain.Entities.Enums;

namespace Wtt.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Grade Grade { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<FoodReservation> FoodReservations { get; set; }
        public virtual ICollection<Presence> Presences { get; set; }
    }
}
