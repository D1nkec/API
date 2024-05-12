using Microsoft.Identity.Client;
using Newtonsoft.Json;
using WebAPIDemo.Dtos.Stock;
using WebAPIDemo.Mapping;
using WebAPIDemo.Models;
using WebAPIDemo.Services.Interfaces;

namespace WebAPIDemo.Services.Implementation
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _configuration = config;
        }



        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_configuration["FMPKey"]}");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    if (stock != null)
                    {
                        return stock.ToStockFromFMP();
                    }
                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
