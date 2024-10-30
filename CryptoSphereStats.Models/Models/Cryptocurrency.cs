namespace CryptoSphereStats.Domain.Models
{
    public class Cryptocurrency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

 
        public ICollection<ChartData> ChartData { get; set; } = new List<ChartData>();

        public ICollection<CryptoData> CryptoData { get; set; } = new List<CryptoData>();
    }
}