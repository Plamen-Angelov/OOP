using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> emplyees = new List<Employee>();
            Employee employee = new Employee("Pesho");
            Employee manager = new Manager("Gosho", new string[] { "doc1", "doc2", "doc3" });
            emplyees.Add(employee);
            emplyees.Add(manager);
            DetailsPrinter dp = new DetailsPrinter(emplyees);

            dp.PrintDetails();
        }
    }
}
