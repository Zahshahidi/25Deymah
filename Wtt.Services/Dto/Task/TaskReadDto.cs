

using System;

namespace Wtt.Services.Dto.Task
{
   public  class TaskReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Domain.Entities.Enums.TaskStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int PerformerId { get; set; }
        public int EmployeeId { get; set; }
    }
}
