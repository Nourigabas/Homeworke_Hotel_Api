﻿using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Employee;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;

namespace Homeworke_Hotel_Api.Services
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int EmployeeId);
        public void DeletEmployee(int EmployeeId); 
        public void CreateEmployye(Employee Employee);
        public void UpdateEmployee(int employeeId, JsonPatchDocument<EmployeeForUpdate> patchDocument);
    }
}
