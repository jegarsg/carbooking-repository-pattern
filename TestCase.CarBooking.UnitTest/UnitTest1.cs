using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestCase.CarBooking.Repository.Models;

namespace TestCase.CarBooking.UnitTest
{
    public class Tests
    {

        RentCarContext _context = new RentCarContext();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var testVehicles= _context.Vehicles.ToListAsync();
            var testCustomer = _context.Customers.ToListAsync();
            var testTransaction = _context.BookingTransactions.ToListAsync();
            Assert.Pass();
        }
    }
}