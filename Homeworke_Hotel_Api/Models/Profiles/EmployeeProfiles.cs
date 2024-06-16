using AutoMapper;
using Homeworke_Hotel_Api.Models.ModelsWithOut;
using Homeworke_Hotel_Api.ViewModels.Employee;

namespace Homeworke_Hotel_Api.Models.Profiles
{
    public class EmployeeProfiles:Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<EmployeeForCreate, Employee>();
            CreateMap<Employee, EmployeeForUpdate>();
            CreateMap<EmployeeForUpdate, Employee>();
            CreateMap<Employee, EmployeeWithOutBooking>();
        }
    }
}
