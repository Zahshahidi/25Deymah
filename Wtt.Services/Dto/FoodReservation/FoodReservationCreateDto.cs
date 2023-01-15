

namespace Wtt.Services.Dto.FoodReservation
{
    public class FoodReservationCreateDto
    {
      

        public int EmployeeId { get; set; }

        public int FoodId { get; set; }

        public DateTime ReservedDate { get; set; }
    }
}
