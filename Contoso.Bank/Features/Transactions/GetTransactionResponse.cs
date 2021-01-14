using Contoso.Bank.Domain;

namespace Contoso.Bank.Features.Transactions
{
    public record GetTransactionResponse
    {
        public string AccountNumber { get; init; }
        
        public double Amount { get; init; }

        public Currency Currency { get; init; }

        public string Id { get; init; }
    }
}
