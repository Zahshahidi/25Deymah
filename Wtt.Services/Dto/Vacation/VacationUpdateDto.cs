using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wtt.Services.Dto.Vacation
{
    public class VacationUpdateDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public int Status { get; set; }

    }
}
