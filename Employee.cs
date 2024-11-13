using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryCalculator
{
    public class Employee
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal BaseSalary { get; set; }

        // Constructor to initialize employee details
        public Employee(string name, string country, decimal baseSalary)
        {
            Name = name;
            Country = country;
            BaseSalary = baseSalary;
        }
    }
}
