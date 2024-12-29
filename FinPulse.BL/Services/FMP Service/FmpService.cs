using FinPulse.DAL;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FinPulse.BL;

public class FmpService(HttpClient httpClient, IConfiguration config) : IFmpService
{
    public async Task<Stock?> FindStockBySymbolAsync(string symbol)
    {
        try
        {
            var apiKey = config["FMPKey"] ?? throw new InvalidOperationException("API key is missing.");
            
            var requestUrl = $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={apiKey}";
            
            var response 
                = await httpClient.GetAsync(requestUrl);
            
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"API call failed. Status Code: {response.StatusCode}");
                return null;
            }
            
            var content = await response.Content.ReadAsStringAsync();
            
            // Deserialize response and validate data
            var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
            if (tasks == null || tasks.Length == 0) return null;
            
            var stock = tasks[0];
            
            return new Stock
            {
                Symbol = stock.symbol,
                CompanyName = stock.companyName,
                Purchase = stock.price,
                LastDiv = stock.lastDiv,
                Industry = stock.industry,
                MarketCap = stock.mktCap
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}