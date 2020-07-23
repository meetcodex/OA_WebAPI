using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get All Employee
        /// </summary>
        /// <returns>Employee List</returns>
        IEnumerable<Employee> GetAllEmployee();

        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="Id">Employee identifier</param>
        /// <returns>Employee</returns>
        Employee GetEmployee(int Id);

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        void AddEmployee(Employee employee);

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        void DeleteEmployee(Employee employee);

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        void UpdateEmployee(Employee employee);

    }
}
