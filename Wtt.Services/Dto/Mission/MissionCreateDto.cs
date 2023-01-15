

namespace Wtt.Services.Dto.Mission
{
    public class MissionCreateDto
    {
      
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

    }
}
