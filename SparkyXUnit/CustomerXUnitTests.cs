﻿using Sparky;
using SparkyXUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
   
    public class CustomerXUnitTests
    {
        private Customer customer;

     
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }


        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            customer.GreetAndCombineNames("Ben", "Spark");
            Assert.Multiple(() =>
            {
                Assert.Equal("Hello, Ben Spark", customer.GreetMessage);
                Assert.Contains("ben spark".ToLower(), customer.GreetMessage.ToLower());
                Assert.StartsWith("Hello,", customer.GreetMessage);
                Assert.EndsWith("Spark", customer.GreetMessage);
                Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
            });
        }


        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);

            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Spark"));      
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 150;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
