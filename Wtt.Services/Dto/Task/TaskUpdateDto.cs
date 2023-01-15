

using System;

namespace Wtt.Services.Dto.Task
{
   public  class TaskUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int PerformerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
