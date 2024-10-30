using CryptoSphereStats.Domain.Models;
using CryptoSphereStats.Domain.Enums;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using CryptoSphereStats.DataAccess.DataContext;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;







namespace CryptoSphereStats
{
    public class GenerateDummyData
    {
        private static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private static readonly string cryptoApi = "https://api.coinlore.net/api/tickers/";

        public class CryptoApiResponse
        {
            public List<CryptoData> Data { get; set; } 
        }

        public static async Task<IEnumerable<ChartData>> FetchCryptoDataAsync(ChartDataContext context)
        {
            try
            {
                var response = await client.GetStringAsync(cryptoApi);
                var apiResponse = JsonConvert.DeserializeObject<CryptoApiResponse>(response);

                if (apiResponse?.Data == null)
                {
                    return Enumerable.Empty<ChartData>();
                }

                var chartDataList = new List<ChartData>();

                foreach (var item in apiResponse.Data)
                {
                    
                    var cryptocurrency = await context.Cryptocurrencies
                        .FirstOrDefaultAsync(c => c.Name == item.Name);

                    if (cryptocurrency == null)
                    {
                      
                        cryptocurrency = new Cryptocurrency { Name = item.Name };
                        context.Cryptocurrencies.Add(cryptocurrency);
                        await context.SaveChangesAsync(); 
                    }

                    // Generate dummy data for the cryptocurrency
                    var dummyData = GenerateDummyChartDataForCrypto(cryptocurrency.Id, item.Name, 12);
                    chartDataList.AddRange(dummyData);
                }

                return chartDataList;
            }
            catch (HttpRequestException ex)
            {
             
                return Enumerable.Empty<ChartData>();
            }
        }

        public static IEnumerable<ChartData> GenerateDummyChartDataForCrypto(int cryptocurrencyId, string cryptoName, int totalPoints = 12)
        {
            var data = new List<ChartData>();
            Random random = new Random();

            for (int i = 0; i < totalPoints; i++)
            {
                data.Add(new ChartData
                {
                    Month = (Month)(i + 1),
                    Value = random.Next(10, 100),
                    Name = cryptoName,
                    CryptocurrencyId = cryptocurrencyId
                });
            }
            return data;
        }

        public async Task FetchAndStoreCryptoData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChartDataContext>();
            optionsBuilder.UseSqlServer("Server=JSNLAP\\SQLEXPRESS;Database=CryptoSphereStatsDatabase;Trusted_Connection=True;TrustServerCertificate=True"); 

            using (var context = new ChartDataContext(optionsBuilder.Options))
            {
                
                var chartData = await GenerateDummyData.FetchCryptoDataAsync(context);
                context.ChartData.AddRange(chartData);
                await context.SaveChangesAsync();
            }
        }

    }
}
