

namespace Wtt.Services.Dto.Mission
{
    public class MissionReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

    }
}
