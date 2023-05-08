using System;
using System.Collections.Generic;


namespace TestCase.CarBooking.Repository.Models
{
    public partial class BookingTransaction
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? CustomerId { get; set; }
        public int? VehicleId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? TotalPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual Vehicle? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }
}
