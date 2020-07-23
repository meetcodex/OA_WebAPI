using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    public class EmployeeService : IEmployeeService
    {
        #region Field
        private IRepository<Employee> _employeeRepository;
        #endregion

        #region Ctor
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Method

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _employeeRepository.Add(employee);
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _employeeRepository.Delete(employee);
        }

        /// <summary>
        /// Get All Employee
        /// </summary>
        /// <returns>Employee List</returns>
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeRepository.GetAll();
        }

        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="Id">Employee identifier</param>
        /// <returns>Employee</returns>
        public Employee GetEmployee(int Id)
        {
            if(Id == 0)
                throw new ArgumentNullException("Id is 0 or null");
            return _employeeRepository.Get(Id);
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee">Employee</param>
        public void UpdateEmployee(Employee employee)
        {
            if(employee == null)
                throw new ArgumentNullException(nameof(employee));

            _employeeRepository.Update(employee);

        }

        #endregion
    }
}
