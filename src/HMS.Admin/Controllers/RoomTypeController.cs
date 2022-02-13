using HMS.Admin.Utils;
using HMS.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomTypeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int page = 1, string search = null)
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{Constants.baseUrl}/api/RoomTypes?page={page}&search={search}");
            var responseJsonStr = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RoomTypeIndexViewModel roomType = JsonConvert.DeserializeObject<RoomTypeIndexViewModel>(responseJsonStr);
                return View(roomType);
            }

            return BadRequest();
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomTypePostViewModel roomType)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string jsonStr = JsonConvert.SerializeObject(roomType);

            StringContent httpContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{Constants.baseUrl}/api/RoomTypes", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                var responseJsonStr = await response.Content.ReadAsStringAsync();
                ResponseViewModel responseVM = JsonConvert.DeserializeObject<ResponseViewModel>(responseJsonStr);
                ModelState.AddModelError("Name", responseVM.Message);
                return View();
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Update

        public async Task<IActionResult> Update(int id)
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{Constants.baseUrl}/api/RoomTypes/{id}");
            var responseJsonStr = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RoomTypeDetailViewModel roomType = JsonConvert.DeserializeObject<RoomTypeDetailViewModel>(responseJsonStr);
                return View(roomType);
            }

            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, RoomTypePostViewModel roomType)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var jsonStr = JsonConvert.SerializeObject(roomType);

            StringContent httpContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{Constants.baseUrl}/api/RoomTypes/{id}", httpContent);

            if (!response.IsSuccessStatusCode)
            {
                var responseJsonStr = await response.Content.ReadAsStringAsync();
                ResponseViewModel responseVM = JsonConvert.DeserializeObject<ResponseViewModel>(responseJsonStr);
                ModelState.AddModelError("Name", responseVM.Message);
                return View();
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{Constants.baseUrl}/api/RoomTypes/{id}");
            var responseJsonStr = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RoomTypeDetailViewModel roomType = JsonConvert.DeserializeObject<RoomTypeDetailViewModel>(responseJsonStr);
                return View(roomType);
            }

            return BadRequest();
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Constants.baseUrl}/api/RoomTypes/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int id)
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{Constants.baseUrl}/api/RoomTypes/{id}");
            var responseJsonStr = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RoomTypeDetailViewModel roomType = JsonConvert.DeserializeObject<RoomTypeDetailViewModel>(responseJsonStr);
                return View(roomType);
            }

            return BadRequest();
        }

        #endregion
    }
}
