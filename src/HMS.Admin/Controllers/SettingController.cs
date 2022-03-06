using HMS.Admin.Resources.SettingResources;
using HMS.Admin.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HMS.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly HttpClient _httpClient;

        public SettingController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{Constants.baseUrl}/api/Settings");
            var responseJsonStr = await httpResponse.Content.ReadAsStringAsync();

            if(httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                SettingItemResource settingItem = JsonConvert.DeserializeObject<SettingItemResource>(responseJsonStr);
                return View(settingItem);
            }

            return BadRequest();
        }
    }
}
