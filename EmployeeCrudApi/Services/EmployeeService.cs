using EmployeeCrudApi.Models;
using System.Xml.Linq;

namespace EmployeeCrudApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new();
        private int _nextId = 1;

        public List<Employee> GetAll() => _employees;

        public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public Employee Add(Employee employee)
        {
            employee.Id = _nextId++;
            _employees.Add(employee);
            return employee;
        }

        public bool Update(int id, Employee updatedEmployee)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.FullName = updatedEmployee.FullName;
            existing.Department = updatedEmployee.Department;
            existing.Salary = updatedEmployee.Salary;
            return true;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee == null) return false;

            _employees.Remove(employee);
            return true;
        }
    }
}
