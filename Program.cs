// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace EmployeeSalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of employees
            List<Employee> employees = new List<Employee>
            {
                new Employee("John Doe", "USA", 5000),
                new Employee("Jane Smith", "Germany", 5500),
                new Employee("Ravi Kumar", "India", 4000),
                new Employee("Chen Wei", "China", 4500),
                new Employee("Alice Brown", "USA", 6000),
                new Employee("Max Müller", "Germany", 6500),
                new Employee("Anil Patel", "India", 4200)
            };

            // Create an instance of the QueryProcessor
            QueryProcessor processor = new QueryProcessor(employees);

            try
            {
                // Query total salary for USA
                decimal totalUSASalary = processor.GetTotalSalaryByCountry("USA");
                Console.WriteLine($"Total Salary in USA: {totalUSASalary}");

                // Query average salary for employees from index 1 to 4
                decimal averageSalary = processor.GetAverageSalary(1, 4);
                Console.WriteLine($"Average Salary (index 1-4): {averageSalary}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}


