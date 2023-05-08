using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCase.CarBooking.Repository.Models;
using TestCase.CarBooking.Repository.Repository;

namespace TestCase.CarBooking.Repository.UoW
{
    public class UnitOfWork : IDisposable
    {
        private RentCarContext context = new RentCarContext();
        private GenericRepository<BookingTransaction> bookingTransactionRepository;
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Vehicle> vehicleRepository;

        public GenericRepository<BookingTransaction> BookingTransactionRepository
        {
            get
            {

                if (this.bookingTransactionRepository == null)
                {
                    this.bookingTransactionRepository = new GenericRepository<BookingTransaction>(context);
                }
                return bookingTransactionRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Vehicle> VehicleRepository
        {
            get
            {

                if (this.vehicleRepository == null)
                {
                    this.vehicleRepository = new GenericRepository<Vehicle>(context);
                }
                return vehicleRepository;
            }
        }







        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
