using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtt.Domain.Entities
{
    public class Project
    { 
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }

        
    }
}
