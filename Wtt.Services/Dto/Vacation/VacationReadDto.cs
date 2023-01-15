

namespace Wtt.Services.Dto.Vacation
{
   public  class VacationReadDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }

    }
}
