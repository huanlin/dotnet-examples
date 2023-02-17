using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ConsoleApp;
using ConsoleApp.DataAccess.Queries;
using ConsoleApp.Models;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        /// <summary>
        /// This test will fail with the following error message:
        /// The source IQueryable doesn't implement IDbAsyncEnumerable<ConsoleApp.Models.Customer>.
        /// </summary>
        [Test]
        public async void Will_Fail_With_InvalidOperationException()
        {
            var customerQueries = Substitute.For<ICustomerQueries>();

            var customers = new Customer[] 
            {
                new Customer {Id=1, Country="USA", Name="Michael", Address="Address 1" },
                new Customer {Id=2, Country="ROC", Name="Jane", Address="Address 2" },
            };

            customerQueries.GetCustomersQuery().Returns(customers.AsQueryable());

            var demo = new Demo(customerQueries);
            var result = await demo.Run();

            result.Length.Should().Be(2);
        }

        /// <summary>
        /// This test should pass.
        /// Note we are not faking DbContext here.
        /// </summary>
        [Test]
        public async void Should_Get_Customers()
        {
            var customerQueries = Substitute.For<ICustomerQueries>();

            var customers = new Customer[] 
            {
                new Customer {Id=1, Country="USA", Name="Michael", Address="Address 1" },
                new Customer {Id=2, Country="ROC", Name="Jane", Address="Address 2" },
            };

            var customerQuery = 
                Substitute
                    .For<DbSet<Customer>, IQueryable<Customer>, IDbAsyncEnumerable<Customer>>()
                    .SetupData(customers);

            customerQueries.GetCustomersQuery().Returns(customerQuery);

            var demo = new Demo(customerQueries);
            var result = await demo.Run();

            result.Length.Should().Be(2);
            result[0].Name.Should().Be(customers[0].Name);
            result[1].Name.Should().Be(customers[1].Name);
        }

    }
}
