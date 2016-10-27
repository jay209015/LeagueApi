using System.Net.Http;
using System.Threading.Tasks;

namespace LeagueApi.ApiCalls {
    public class Base {

        public string BaseUrl = "https://na.api.pvp.net/api/lol/na";
        public string ApiKey = "RGAPI-d6fbfa6e-b7da-4158-9980-2b3add3a37a7";
        public void main() {
            
        }

        public async Task<string> SendRequest(string EndPoint) {
            using (var client = new HttpClient())
            {
                try
                {
                    EndPoint = BaseUrl + EndPoint  + "?api_key=" + ApiKey;
                    var response = await client.GetAsync(EndPoint);
                    response.EnsureSuccessStatusCode();

                    var stringResponse = await response.Content.ReadAsStringAsync();
        
                    return stringResponse;
                }
                catch (HttpRequestException)
                {
                    return "";
                }
            }
        }
    }
}