

namespace Wtt.Services.Dto.Presence
{
    public class PresenceUpdateDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string Description { get; set; }
    }
}
