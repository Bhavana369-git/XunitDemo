using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeSalaryCalculator
{
    public class QueryProcessor : EmployeeSalaryCalculator
    {
        private List<Employee> _employees;

        // Constructor to initialize the list of employees
        public QueryProcessor(List<Employee> employees)
        {
            _employees = employees;
        }

        // Implement the abstract method to get total salary by country using LINQ
        public override decimal GetTotalSalaryByCountry(string country)
        {
            // Using LINQ to filter employees by country and calculate the total adjusted salary
            decimal totalSalary = _employees
                .Where(emp => emp.Country.Equals(country, StringComparison.OrdinalIgnoreCase))
                .Sum(emp => AdjustSalaryBasedOnCountry(emp));  // Apply salary adjustment

            return totalSalary;
        }

        // Implement the abstract method to get average salary for a range of employees using LINQ
        public override decimal GetAverageSalary(int startIndex, int endIndex)
        {
            // Ensure valid indices
            if (startIndex < 0 || endIndex >= _employees.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid range specified.");
            }

            // Using LINQ to select the range of employees (using Skip and Take)
            var selectedEmployees = _employees.Skip(startIndex).Take(endIndex - startIndex + 1);

            // Calculate total salary of selected employees using LINQ
            decimal totalSalary = selectedEmployees
                .Sum(emp => AdjustSalaryBasedOnCountry(emp));  // Apply salary adjustment

            // Return the average salary
            return totalSalary / selectedEmployees.Count();
        }
    }
}

