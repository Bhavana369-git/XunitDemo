# XunitDemo
Debugging During Test Execution
You can also inspect certain aspects of your tests in real-time while they are running:
Immediate Window: Use the Immediate window (Ctrl + Alt + I) to evaluate expressions while debugging.
Watch Window: Add specific variables or expressions to the Watch window to monitor their values during the execution.
Call Stack: The Call Stack window shows you the current method call hierarchy, which is helpful if you're stepping through code that calls other methods.
Example Debugging a Test
Let’s walk through an example of debugging the GetTotalSalaryByCountry_ShouldReturnCorrectTotal_ForUSA test.
Set a breakpoint at the beginning of the test method:

 code[Fact]
 
 public void GetTotalSalaryByCountry_ShouldReturnCorrectTotal_ForUSA()
 
 {
 
    // Set breakpoint here
    var employees = GetTestEmployees();
    var processor = new QueryProcessor(employees);
        // Act: Get the total salary for USA
        decimal totalSalary = processor.GetTotalSalaryByCountry("USA");
    // Assert: Verify that the total salary for USA is correctly calculated
    decimal expectedTotalSalary = 5000 * 0.85m + 6000 * 0.85m; 
    // 15% tax deduction
    Assert.Equal(expectedTotalSalary, totalSalary);
    
}
 
Open Test Explorer and right-click on the test GetTotalSalaryByCountry_ShouldReturnCorrectTotal_ForUSA.
Choose Debug Selected Tests.
Visual Studio will hit the breakpoint, and you can start debugging by stepping through each line of code.
Inspect values such as totalSalary and expectedTotalSalary using the Locals or Watch window to verify the calculations.
After the test completes, Visual Studio will show whether the test passed or failed, and you can analyze the results.
Additional Tips for Efficient Debugging
Debugging Helper Methods: If your test relies on helper methods (like GetTestEmployees()), set breakpoints inside those helper methods too, especially if the issue seems related to the test setup.
Use Conditional Breakpoints: If you're debugging a loop or a large test method, you can use conditional breakpoints to pause execution only when certain conditions are met. Right-click on the breakpoint and choose Conditions, then specify a condition (e.g., break only when a variable equals a certain value).
Use Debug.Assert: For more advanced debugging, you can place Debug.Assert statements inside your code to verify certain conditions during runtime. This is useful for catching issues even when running without a full debugger.
