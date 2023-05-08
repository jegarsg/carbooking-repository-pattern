using System;
using System.Collections.Generic;

namespace TestCase.CarBooking.Repository.Models
{


    public partial class SearchCarDTO
    {
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }


}
