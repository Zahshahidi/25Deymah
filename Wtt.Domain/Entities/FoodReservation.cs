using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtt.Domain.Entities
{
    public class FoodReservation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int FoodId { get; set; }
        public DateTime ReservedDate { get; set; }
        public virtual Food Food { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
