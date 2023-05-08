using System;
using System.Collections.Generic;

namespace TestCase.CarBooking.Repository.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
