using BanDoMba.EF;
using BanDoMba.Models;
using BanDoMba.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BanDoMba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMbaService _mbaService;

        public HomeController(ILogger<HomeController> logger, IMbaService mbaService)
        {
            _logger = logger;
            _mbaService = mbaService;
        }

        public IActionResult Index()
        {
          
            var locations = new List<DeviceLocation>();
           
                locations.Add(new DeviceLocation { TenTram = $"1", Latitude = 21.036970d, Longitude = 105.849912, MoTa = "CS15" });
            
            return View(locations);

        }
        public async Task<IActionResult> ViewMap(int id, string madvi, decimal lat, decimal lon)
        {
            var data = await _mbaService.DeviceLocation(id);
            var dataLocation = new DataLocation();
            var locations = new List<DeviceLocation>();
            if (data != null)
            {
                locations.Add(new DeviceLocation { TenTram = $"{data.TenTram}-{data.MaTram}", Latitude = data.Latitude, Longitude = data.Longitude, MoTa = data.MoTa });
                dataLocation.ListTba = locations;
            }
            dataLocation.Latitude = lat; dataLocation.Longitude = lon;
            return View(dataLocation);
        }

        public async Task<IActionResult> Info()
        {
            var data = await _mbaService.GetInfo();
            return View(data);
        }

        public async Task<IActionResult> RegionalDiagram(string madvi)
        {
            var data = await _mbaService.ListDeviceLocation(madvi);
            
            var locations = new List<DeviceLocation>();
            if (data != null && data.Count > 0)
            {
                foreach (var location in data) {
                    locations.Add(new DeviceLocation { TenTram = $"{location.TenTram}-{location.MaTram}", Latitude = location.Latitude, 
                        Longitude = location.Longitude, MoTa = location.MoTa });
                }
                
            }
            return View(locations);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
