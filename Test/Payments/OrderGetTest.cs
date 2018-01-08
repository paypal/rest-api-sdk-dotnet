using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;
using Xunit;
using PayPal.Test;
using static PayPal.Test.TestHarness;

namespace PayPal.Payments.Test
{
    [Collection("Payments")]
    public class OrderGetTest
    {

        public static string FAKE_ID = "O-2FK09787H36911800";

        [Fact(Skip="Tests that use this class must be ignored when run in an automated environment because executing an order will require approval via the executed payment\'s approval_url")]
        public async void TestOrderGetRequest()
        {
            
            OrderGetRequest request = new OrderGetRequest(FAKE_ID);

            HttpResponse response = await TestHarness.client().Execute(request);
            Assert.Equal((int) response.StatusCode, 200);
            Assert.NotNull(response.Result<Order>());
        }
    }
}
