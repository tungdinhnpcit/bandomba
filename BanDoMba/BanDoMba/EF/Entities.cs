namespace BanDoMba.EF
{
    public class Entities
    {
    }

    public class CallApiDataModel<T>
    {
        public bool? status { get; set; }
        public string? message { get; set; }
        public T? data { get; set; }
    }

    public class CallApiListDataModel<T>
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public List<T>? data { get; set; }
    }
    public class Info
    {
        public string? UrlInfo {  get; set; }
        public List<OrganizationModel>? Data {  get; set; }
    }
    public class OrganizationModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? OrgCode { get; set; }
        public string? OrgName { get; set; }
        public string? Level { get; set; }
    }
    public class DataLocation
    {
        public decimal ? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public List<DeviceLocation>? ListTba {  get; set; }
    }
    public class DeviceLocation
    {
        public string? MaDvi { get; set; }
        public string? MaTram { get; set; }
        public string? TenTram { get; set; }
        public string? MoTa { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
