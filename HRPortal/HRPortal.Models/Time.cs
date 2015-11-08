using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Time
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmpID { get; set; }

        [Range(0, 16, ErrorMessage = "Can only enter up to 16")]
        public int HoursWorked { get; set; }

        [DataType(DataType.Date)]
        public string[] Date { get; set; }
    }
}
