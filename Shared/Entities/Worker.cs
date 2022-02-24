using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HomeProject.Shared.Entities
{
    public class Worker
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
}