using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Models
{
    internal class ApiContext
    {
        private readonly HttpClient httpClient;

        public ApiContext()
        {
            httpClient = new HttpClient();
        }
        
        public async Task<List<Cryptocurrency>> GetCryptocurrencies()
        {
            string url = "https://api.coincap.io/v2/assets?limit=200";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            var cryptoList = new List<Cryptocurrency>();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            var dataArray = jsonObject.data;

            foreach (var item in dataArray)
            {
                Cryptocurrency cryptocurrency = new Cryptocurrency
                {
                    id = item.id,
                    rank = item.rank,
                    symbol = item.symbol,
                    name = item.name,
                    supply = item.supply,
                    maxSupply = item.maxSupply == null ? "Infinite" : item.maxSupply,
                    marketCapUsd = item.marketCapUsd,
                    volumeUsd24Hr = item.volumeUsd24Hr,
                    priceUsd = item.priceUsd,
                    changePercent24Hr = item.changePercent24Hr,
                    vwap24Hr = item.vwap24Hr,
                    imageUrl = $"https://assets.coincap.io/assets/icons/{item.symbol.ToString().ToLower()}@2x.png"
                };
                cryptoList.Add(cryptocurrency);

            }
            return cryptoList;

        }
    }
}
