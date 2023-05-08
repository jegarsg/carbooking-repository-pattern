using Microsoft.EntityFrameworkCore;
using TestCase.CarBooking.Repository.Models;
using TestCase.CarBooking.Repository.UoW;

namespace TestCase.CarBooking.WebApi.Services
{
    public class CarBookingService
    {
        private UnitOfWork _uow;
        public CarBookingService(UnitOfWork uow)
        {   
            _uow = uow;
        }

        public List<Vehicle> GetVehicles()
        {
            return _uow.VehicleRepository.Get().ToList();
        }

        public List<Vehicle> SearchVehicle(SearchCarDTO itemDTO)
        {
            List<Vehicle> output = new List<Vehicle>();
            var item= _uow.VehicleRepository.Get(x => x.Description.Contains(itemDTO.Description)
            || x.Type.Contains(itemDTO.Type)
            || x.X == itemDTO.X
            || x.Y == itemDTO.Y).ToList();
            return item;
        }

        public Vehicle GetVehicle(int id)
        {
            return _uow.VehicleRepository.GetByID(id);
        }

        public string BookTransactionMethod(BookingTransactionItemDTO itemDTO)
        {
            //Try to validate vehicle in range or not. 
            bool validRange = ValidateRangeBookingTransaction(itemDTO);
            bool validAvailable = ValidateAvailableBookingTransaction(itemDTO);
            string message = "Booking car is complete.";

            if (!validRange)
            {
                message = "this car is not your range";
                return message;
            }
            if(!validAvailable)
            {
                message = "this car already booking";
                return message;
            }
            if (validRange & validAvailable)
            {
                var itemVehicle = _uow.VehicleRepository.GetByID(itemDTO.VehicleId);

                var itemCustomer = _uow.CustomerRepository.GetByID(itemDTO.CustomerId);


                var newTransaction = new BookingTransaction();
                {
                    newTransaction.Description = itemDTO.Description;
                    newTransaction.CustomerId = itemDTO.CustomerId;
                    newTransaction.VehicleId = itemDTO.VehicleId;
                    newTransaction.StartDate = itemDTO.StartDate;
                    newTransaction.EndDate = itemDTO.EndDate;
                    newTransaction.CreatedDate = DateTime.Today;
                    newTransaction.CreatedBy = "Administrator";
                };

                itemVehicle.IsBooking = true;
                //summary price
                int totalDay = (itemDTO.EndDate - itemDTO.StartDate).Days;
                var totalPrice = Convert.ToDecimal(itemVehicle.Price) * totalDay;
                newTransaction.TotalPrice = totalPrice.ToString();

                //update new customerlocation
                itemCustomer.X = itemDTO.XCustomer;
                itemCustomer.Y = itemDTO.YCustomer;
                try
                {

                    _uow.BookingTransactionRepository.Insert(newTransaction);
                    _uow.CustomerRepository.Update(itemCustomer);
                    _uow.Save();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                message = "not available";
               
            }
           
            return message;
        }

        public List<Vehicle>  GetVehicleByNearby(VehicleItemDTO vehicleItemDTO)
        {
            List<Vehicle> output = new List<Vehicle>();

            //check if vehicles is in range or not. Will show all vehicles which in range, after validation
            foreach (var item in _uow.VehicleRepository.Get())
            {
                vehicleItemDTO.VehicleId = item.Id;

                if (ValidateRangeBookingTransaction(vehicleItemDTO))
                {
                    output.Add(item);
                }
            }

            //Update customer location
            var itemCustomer = _uow.CustomerRepository.GetByID(vehicleItemDTO.CustomerId);
            if (itemCustomer != null)
            {
                //update new customerlocation
                itemCustomer.X = vehicleItemDTO.XCustomer;
                itemCustomer.Y = vehicleItemDTO.YCustomer;
                try
                {
                    _uow.CustomerRepository.Update(itemCustomer);
                    _uow.Save();
                }
                catch (Exception ex)
                {

                }
            }

            return output.ToList();
        }


        //Try to validate vehicle car available
        private bool ValidateAvailableBookingTransaction(VehicleItemDTO vehicleItemDTO)
        {
            bool result = false;
            var item = _uow.VehicleRepository.Get().Where(a=>a.Id==vehicleItemDTO.VehicleId).FirstOrDefault();
            

            if (item != null)
            {
                //Check is vehicle status are available or not
                bool isAvailable = _uow.VehicleRepository.Get(x => x.Id == vehicleItemDTO.VehicleId).FirstOrDefault()?.IsBooking==false;

                if (isAvailable)
                    result = true;
            }
   

            return result;
        }
        //Try to validate car location is in range
        private bool ValidateRangeBookingTransaction(VehicleItemDTO vehicleItemDTO)
        {
            bool result = false;
            var item = _uow.VehicleRepository.GetByID(vehicleItemDTO.VehicleId);

            if (item != null)
            {
                //Check if vehicle location is in range
                bool isInRange = (item.X - vehicleItemDTO.XCustomer) + (item.Y - vehicleItemDTO.YCustomer) <= 2;
                if (isInRange)
                    result = true;
            }
    

            return result;
        }

    }
}
