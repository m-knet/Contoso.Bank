using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contoso.Bank._3_1;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace Contoso.Bank.FunctionalTests._3_1.Steps
{
    [Binding]
    public sealed class GetTransactionDefinitions : WebApplicationFactory<Startup>
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _response;

        [Given("a client without authentication")]
        public void GivenAClient()
        {
            _httpClient = CreateClient();
        }

        [When("transactions are required")]
        public async Task WhenTransactionIsSent()
        {
            _response = await _httpClient.GetAsync("transactions");
        }

        [When("a new transaction is sent")]
        public async Task WhenANewTransactionIsSent()
        {
            var json = new StringContent(JsonConvert.SerializeObject(new
            {
                Account = Guid.NewGuid().ToString()
            }), Encoding.UTF8, "application/json");

            _response = await _httpClient.PostAsync("transactions", json);
        }

        [Then("status code should be (.*)")]
        public void ThenTheResultShouldBe(int code)
        {
            var httpStatusCode = (HttpStatusCode) code;

            _response.StatusCode.Should().Be(httpStatusCode);
        }
    }
}
