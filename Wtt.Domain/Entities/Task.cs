using Wtt.Domain.Entities.Enums;

namespace Wtt.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int PerformerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
