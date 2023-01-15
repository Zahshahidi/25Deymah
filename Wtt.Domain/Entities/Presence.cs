using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtt.Domain.Entities
{
    public class Presence
    { 
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string Description { get; set; }
        public virtual Employee Employee { get; set; }

        
    }


}
