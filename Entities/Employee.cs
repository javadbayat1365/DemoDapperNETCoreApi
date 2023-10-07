using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
        public string? CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
}
