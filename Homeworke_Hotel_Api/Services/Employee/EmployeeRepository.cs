using AutoMapper;
using Homeworke_Hotel_Api.Data;
using Homeworke_Hotel_Api.Models;
using Homeworke_Hotel_Api.ViewModels.Employee;
using Homeworke_Hotel_Api.ViewModels.Hotel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.XPath;

namespace Homeworke_Hotel_Api.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataBaseContext context;
        private readonly IMapper mapper;

        public EmployeeRepository(DataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Employee> GetEmployees()
        {
            var respone = context.Employees
                                 .Where(e => e.IsDeleted == false)
                                 .Include(e=>e.Bookings)
                                 .ToList();
            return respone;
        }
        public Employee GetEmployee(int BookingId)
        {
            var respone = context.Employees
                                 .Where(e => e.Id == BookingId && e.IsDeleted == false)
                                 .Include(e => e.Bookings)
                                 .FirstOrDefault();
            return respone;
        }
        public void CreateEmployye(Employee Employee)
        {
            context.Employees.Add(Employee);
            context.SaveChanges();
        }

        public void DeletEmployee(int BookingId)
        {
            var respone =  context.Employees.FirstOrDefault(e => e.Id == BookingId);
            respone.IsDeleted = true;
            context.SaveChanges();

        }
        public void UpdateEmployee(int employeeId, JsonPatchDocument<EmployeeForUpdate> patchDocument)
        {
            var Employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);
            var EmployeeToPatch = mapper.Map<EmployeeForUpdate>(Employee);
            patchDocument.ApplyTo(EmployeeToPatch);
            mapper.Map(EmployeeToPatch, Employee);
            context.SaveChanges();
            return;
        }
    }
}
