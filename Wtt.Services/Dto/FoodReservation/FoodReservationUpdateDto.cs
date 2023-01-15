using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtt.Services.Dto.FoodReservation
{
    public class FoodReservationUpdateDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int FoodId { get; set; }

        public DateTime ReservedDate { get; set; }
    }
}
