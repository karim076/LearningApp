using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnApp.Models
{
    internal class Building
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public ICollection<Employees> Workers { get; set; } = null; // has many employees
    }
}
