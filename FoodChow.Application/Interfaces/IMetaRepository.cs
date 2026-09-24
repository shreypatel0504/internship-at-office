namespace FoodChow.Application.Interfaces
{
    public class VehicleTypeRow
    {
        public string? id { get; set; }
        public int weight { get; set; }
        public string? name { get; set; }
    }

    public class MetaSettingRow
    {
        public string? setting_key { get; set; }
        public string? setting_value { get; set; }
    }

    public class MetaTypesRawResult
    {
        public List<VehicleTypeRow> Vehicles { get; set; } = new();
        public List<MetaSettingRow> Settings { get; set; } = new();
    }

    public interface IMetaRepository
    {
        Task<bool> IsLocationServiceableAsync(double latitude, double longitude);
        Task<MetaTypesRawResult> GetMetaTypesAsync();
    }
}