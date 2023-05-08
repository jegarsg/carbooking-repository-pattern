using System;
using System.Collections.Generic;

namespace TestCase.CarBooking.Repository.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            BookingTransactionCustomers = new HashSet<BookingTransaction>();
            BookingTransactionVehicles = new HashSet<BookingTransaction>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public bool IsBooking { get; set; }
        public string? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual ICollection<BookingTransaction> BookingTransactionCustomers { get; set; }
        public virtual ICollection<BookingTransaction> BookingTransactionVehicles { get; set; }
    }
}
