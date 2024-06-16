﻿using System.ComponentModel.DataAnnotations;

namespace Homeworke_Hotel_Api.ViewModels.Employee
{
    public class EmployeeForUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public int HotelId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
