

namespace Wtt.Services.Dto.FoodReservation
{
    public class FoodReservationReadDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int FoodId { get; set; }

        public DateTime ReservedDate { get; set; }
    }
}
