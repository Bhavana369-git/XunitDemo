using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeSalaryCalculator
{
    public abstract class EmployeeSalaryCalculator
    {
        // Protected method to adjust salary based on the country.
        protected decimal AdjustSalaryBasedOnCountry(Employee employee)
        {
            decimal adjustedSalary = employee.BaseSalary;
            switch (employee.Country.ToLower())
            {
                case "usa":
                    adjustedSalary = employee.BaseSalary * 0.85m; // 15% tax deduction for USA
                    break;
                case "germany":
                    adjustedSalary = employee.BaseSalary * 0.80m; // 20% tax deduction for Germany
                    break;
                case "india":
                    adjustedSalary = employee.BaseSalary * 1.1m;  // 10% salary increase for India
                    break;
                case "china":
                    adjustedSalary = employee.BaseSalary * 0.9m;  // 10% tax adjustment for China
                    break;
                default:
                    // No adjustments for other countries
                    break;
            }
            return adjustedSalary;
        }

        // Abstract method to calculate total salary by country
        public abstract decimal GetTotalSalaryByCountry(string country);

        // Abstract method to calculate average salary for a given range of employees
        public abstract decimal GetAverageSalary(int startIndex, int endIndex);
    }
}
