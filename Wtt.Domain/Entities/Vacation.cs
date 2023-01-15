using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wtt.Domain.Entities.Enums;

namespace Wtt.Domain.Entities
{
    public class Vacation 
    { 
        public int Id { get; set; } 
        public int EmployeeId { get; set; } 
        public DateTime Date { get; set; } 
        public VacationStatus Status { get; set; } 
        public virtual Employee Employee { get; set; }

       
    }
}
