namespace CryptoSphereStats.Models
{
    public class ChartData
    {
        public int Id { get; set; }
        public int Month { get; set; } // Represents the month (0-11)
        public int Value { get; set; } // Random value between 0 and 99
    }

}
