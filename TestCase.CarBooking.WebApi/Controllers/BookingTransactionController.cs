using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCase.CarBooking.Repository.Models;
using TestCase.CarBooking.WebApi.Services;

namespace TestCase.CarBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingTransactionController : ControllerBase
    {
        private readonly RentCarContext _context;
        private readonly CarBookingService _carBookingService;
        public BookingTransactionController(RentCarContext context, CarBookingService carBookingService)
        {
            _context = context;
            _carBookingService = carBookingService;
        }

        // GET: api/Vehicles
        [HttpGet("GetVehicles")]
        public ActionResult<IList<Vehicle>> GetVehicles()
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            return _carBookingService.GetVehicles();
        }


        [HttpPost("SearchVehicle")]
        public ActionResult<List<Vehicle>> SearchVehicle(SearchCarDTO itemDTO)
        {
            return _carBookingService.SearchVehicle(itemDTO);
        }


        // GET: api/Vehicles/5
        [HttpGet("GetVehicle/{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            return _carBookingService.GetVehicle(id);
        }
      

        // POST: api/Vehicles
        [HttpPost("BookingCar")]
        public async Task<ActionResult<string>> BookTransactionMethod(BookingTransactionItemDTO itemDTO)
        {
            return _carBookingService.BookTransactionMethod(itemDTO);
        }

        [HttpPost("GetVehicleByNearby")]
        public  List<Vehicle> GetVehicleByNearby(VehicleItemDTO vehicleItemDTO)
        {
            return _carBookingService.GetVehicleByNearby(vehicleItemDTO).ToList();
        }

       
        
    }
}
