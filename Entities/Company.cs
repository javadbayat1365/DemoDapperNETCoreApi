using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Employee> Employees { get; set; } = new List<Employee>();
    
}
}
