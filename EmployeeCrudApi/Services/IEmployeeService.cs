using EmployeeCrudApi.Models;
using System.Collections.Generic;

namespace EmployeeCrudApi.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee? GetById(int id);
        Employee Add(Employee employee);
        bool Update(int id, Employee updatedEmployee);
        bool Delete(int id);
    }
}
