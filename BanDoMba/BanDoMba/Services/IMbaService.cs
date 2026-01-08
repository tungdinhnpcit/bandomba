using BanDoMba.EF;

namespace BanDoMba.Services
{
    public interface IMbaService
    {
        public Task<DeviceLocation> DeviceLocation(int id);
        public Task<List<DeviceLocation>> ListDeviceLocation(string org);
        public Task<Info> GetInfo();
    }
}
