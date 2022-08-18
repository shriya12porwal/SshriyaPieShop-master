using Newtonsoft.Json;

namespace SshriyaPieShop.Models
{
    public static class ConnectApi
    {

        public static async Task<IEnumerable<Pie>> GetApiData(string ApiAddress)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);//convert json to student array
                }
            }
           
            return pies;
            //Because return type is task that's why recieve is result 
        }
    }
}
