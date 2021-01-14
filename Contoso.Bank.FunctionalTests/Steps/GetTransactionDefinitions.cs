using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;

namespace Contoso.Bank.FunctionalTests.Steps
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
            _response = await _httpClient.PostAsJsonAsync("transactions", new
            {
                Account = Guid.NewGuid().ToString()
            });
        }

        [Then("status code should be (.*)")]
        public void ThenTheResultShouldBe(int code)
        {
            var httpStatusCode = (HttpStatusCode) code;

            _response.StatusCode.Should().Be(httpStatusCode);
        }
    }
}
