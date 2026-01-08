using BanDoMba.EF;
using BanDoMba.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace BanDoMba.Services
{
    public class MbaService : IMbaService
    {
        private readonly string _apiUrl;

        public MbaService(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        public async Task<DeviceLocation> DeviceLocation(int id)
        {
            var deviceLocation = new DeviceLocation();
            try
            {
                string apiUrl = $"{_apiUrl}/Mba/DeviceLocation?id={id}";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var assetDataString = await response.Content.ReadAsStringAsync();
                        var assetData = JsonConvert.DeserializeObject<CallApiDataModel<DeviceLocation>>(assetDataString);
                        if (assetData != null && assetData.data != null)
                        {
                            deviceLocation = assetData.data;
                        }
                    }
                }
            }
            catch (Exception ex) { 
            
            }
            

            return deviceLocation;
        }

        public async Task<List<DeviceLocation>> ListDeviceLocation(string org)
        {
            var deviceLocation = new List<DeviceLocation>();
            string apiUrl = $"{_apiUrl}/Mba/ListDeviceLocation";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var data = new
                {
                    MaDvi = org
                };
                string json = System.Text.Json.JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var assetDataString = await response.Content.ReadAsStringAsync();
                    var assetData = JsonConvert.DeserializeObject<CallApiListDataModel<DeviceLocation>>(assetDataString);
                    if (assetData != null && assetData.data != null)
                    {
                        deviceLocation = assetData.data;
                    }
                }
            }

            return deviceLocation;
        }
        public async Task<Info> GetInfo()
        {
            var info = new Info();
            info.UrlInfo = _apiUrl;
            try
            {
                string apiUrl = $"{_apiUrl}/Mba/GetTheListOfOrg?orgCode=PA&type=1";
                info.UrlInfo = _apiUrl;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var assetDataString = await response.Content.ReadAsStringAsync();
                        var assetData = JsonConvert.DeserializeObject<CallApiListDataModel<OrganizationModel>>(assetDataString);
                        if (assetData != null && assetData.data != null)
                        {
                            info.Data = assetData.data;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            
            return info;
        }
    }
}
