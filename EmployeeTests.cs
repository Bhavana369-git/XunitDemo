using System;
using System.Collections.Generic;
using Xunit;
using EmployeeSalaryCalculator; // The namespace for your main project

namespace EmployeeSalaryCalculator.Tests
{
    public class QueryProcessorTests
    {
        // Test setup: This method returns a predefined list of employees
        private List<Employee> GetTestEmployees()
        {
            return new List<Employee>
            {
                new Employee("John Doe", "USA", 5000),
                new Employee("Jane Smith", "Germany", 5500),
                new Employee("Ravi Kumar", "India", 4000),
                new Employee("Chen Wei", "China", 4500),
                new Employee("Alice Brown", "USA", 6000),
                new Employee("Max Müller", "Germany", 6500),
                new Employee("Anil Patel", "India", 4200)
            };
        }

        // Test case 1: Calculate total salary for USA
        [Fact]
        public void GetTotalSalaryByCountry_ShouldReturnCorrectTotal_ForUSA()
        {
            // Arrange: Create the processor and provide test data
            var employees = GetTestEmployees();
            var processor = new QueryProcessor(employees);

            // Act: Get the total salary for USA
            decimal totalSalary = processor.GetTotalSalaryByCountry("USA");

            // Assert: Verify that the total salary for USA is correctly calculated
            decimal expectedTotalSalary = 5000 * 0.85m + 6000 * 0.85m; // USA has 15% tax deduction
            Assert.Equal(expectedTotalSalary, totalSalary);
        }

        // Test case 2: Calculate total salary for Germany
        [Fact]
        public void GetTotalSalaryByCountry_ShouldReturnCorrectTotal_ForGermany()
        {
            // Arrange: Provide the employees list and initialize QueryProcessor
            var employees = GetTestEmployees();
            var processor = new QueryProcessor(employees);

            // Act: Get the total salary for Germany
            decimal totalSalary = processor.GetTotalSalaryByCountry("Germany");

            // Assert: Verify that the total salary for Germany is correctly calculated
            decimal expectedTotalSalary = 5500 * 0.80m + 6500 * 0.80m; // Germany has 20% tax deduction
            Assert.Equal(expectedTotalSalary, totalSalary);
        }

        // Test case 3: Calculate the average salary from employee index 1 to 4
        [Fact]
        public void GetAverageSalary_ShouldReturnCorrectAverage_ForIndexRange1To4()
        {
            // Arrange: Provide the list of employees
            var employees = GetTestEmployees();
            var processor = new QueryProcessor(employees);

            // Act: Get the average salary for employees between index 1 and 4
            decimal averageSalary = processor.GetAverageSalary(1, 4);

            // Assert: Verify that the calculated average is correct
            decimal expectedAverageSalary = (5500 * 0.80m + 4000 * 1.1m + 4500 * 0.9m + 6000 * 0.85m) / 4;
            Assert.Equal(expectedAverageSalary, averageSalary);
        }

        // Test case 4: Ensure ArgumentOutOfRangeException is thrown for invalid index range (startIndex > endIndex)
        [Fact]
        public void GetAverageSalary_ShouldThrowArgumentOutOfRangeException_WhenIndexIsInvalid()
        {
            // Arrange: Prepare employee data
            var employees = GetTestEmployees();
            var processor = new QueryProcessor(employees);

            // Act & Assert: Ensure exception is thrown for invalid index range (start > end)
            Assert.Throws<ArgumentOutOfRangeException>(() => processor.GetAverageSalary(4, 1));
        }

        // Test case 5: Ensure ArgumentOutOfRangeException is thrown for out-of-range index
        [Fact]
        public void GetAverageSalary_ShouldThrowArgumentOutOfRangeException_WhenIndexOutOfRange()
        {
            // Arrange: Prepare employee data
            var employees = GetTestEmployees();
            var processor = new QueryProcessor(employees);

            // Act & Assert: Ensure exception is thrown when index is out of the valid range (e.g., 0 to 10)
            Assert.Throws<ArgumentOutOfRangeException>(() => processor.GetAverageSalary(0, 10));
        }

        // Test case 6: Ensure total salary for a non-existent country returns zero
        [Fact]
        public void GetTotalSalaryByCountry_ShouldReturnZero_ForNonExistentCountry()
        {
            // Arrange: Prepare the employee data
            var employees = GetTestEmployees();
            var processor = new QueryProcessor(employees);

            // Act: Try to get the total salary for a non-existent country
            decimal totalSalary = processor.GetTotalSalaryByCountry("NonExistent");

            // Assert: Ensure the total salary is zero
            Assert.Equal(0m, totalSalary);
        }
    }
}

