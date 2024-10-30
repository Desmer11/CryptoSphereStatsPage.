namespace CryptoSphereStats.Domain.Models
{
    public class CryptoData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Rank { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal PercentChange24h { get; set; }

        // Foreign key for Cryptocurrency
        public int CryptocurrencyId { get; set; } 
        public Cryptocurrency Cryptocurrency { get; set; } 
    }
}
