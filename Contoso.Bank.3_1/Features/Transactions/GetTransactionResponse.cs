using Contoso.Bank._3_1.Domain;

namespace Contoso.Bank._3_1.Features.Transactions
{
    public class GetTransactionResponse
    {
        public string AccountNumber { get; set; }
        
        public double Amount { get; set; }

        public Currency Currency { get; set; }

        public string Id { get; set; }
    }
}
