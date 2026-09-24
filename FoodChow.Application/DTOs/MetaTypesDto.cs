namespace FoodChow.Application.DTOs
{
    public class VehicleTypeDto
    {
        public string Id { get; set; } = string.Empty;
        public int Weight { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class MetaTypesDataDto
    {
        public List<VehicleTypeDto> Vehicle { get; set; } = new();
        public List<string> GoodsTypes { get; set; } = new();
        public List<string> CancellationReasons { get; set; } = new();
        public string CustomerCareNumber { get; set; } = string.Empty;
        public string PreferedOperatingHours { get; set; } = string.Empty;
    }

    public class MetaTypesResponseDto
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public MetaTypesDataDto? Data { get; set; }
    }
}