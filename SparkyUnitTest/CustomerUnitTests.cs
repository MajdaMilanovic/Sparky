using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyUnitTest
{
    [TestFixture]
    public class CustomerUnitTests
    {
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }


        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            customer.GreetAndCombineNames("Ben", "Spark");
            Assert.Multiple(() =>
            {
                ClassicAssert.AreEqual(customer.GreetMessage, "Hello, Ben Spark");
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("ben").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }


        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            ClassicAssert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            ClassicAssert.IsNotNull(customer.GreetMessage);

            ClassicAssert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage)); 
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            ClassicAssert.AreEqual("Empty First Name", exceptionDetails.Message);

            Assert.That(() => customer.GreetAndCombineNames("", "spark"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));

            Assert.That(() => customer.GreetAndCombineNames("", "spark"), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 150;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
