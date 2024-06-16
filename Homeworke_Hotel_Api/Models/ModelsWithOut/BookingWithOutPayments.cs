﻿using System.ComponentModel.DataAnnotations;

namespace Homeworke_Hotel_Api.Models.ModelsWithOut
{
    public class BookingWithOutPayments
    {
        public int Id { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime CheckoutAt { get; set; }
        public decimal Price { get; set; }
        public int EmployeeId { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
    }
}