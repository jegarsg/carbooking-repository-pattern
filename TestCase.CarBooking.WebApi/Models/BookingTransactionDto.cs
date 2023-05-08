using System;
using System.Collections.Generic;

namespace TestCase.CarBooking.Repository.Models
{

    public class BookingTransactionItemDTO: VehicleItemDTO
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }

    public class VehicleItemDTO
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public int XCustomer { get; set; }
        public int YCustomer { get; set; }
    }

}
