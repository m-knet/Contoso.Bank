using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Contoso.Bank.Domain;

namespace Contoso.Bank.Features.Transactions
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GetTransactionResponse> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new GetTransactionResponse
                {
                    Amount = new Random().NextDouble(),
                    Currency = Currency.EUR,
                    Id = Guid.NewGuid().ToString(),
                    AccountNumber = Guid.NewGuid().ToString()
                })
            .ToArray();
        }
    }
}
