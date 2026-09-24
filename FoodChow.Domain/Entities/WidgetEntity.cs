namespace FoodChow.Domain.Entities
{
    public class SeoConfigEntity
    {
        public int Id { get; set; }
        public long ShopId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class WidgetSettingEntity
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public int EmailRequired { get; set; }
        public int EmailCompulsary { get; set; }
        public string ColorPicker { get; set; }
        public int EmailVerified { get; set; }
        public int OtpVerified { get; set; }
        public string WidgetSetting { get; set; }
        public string WebsiteColor { get; set; }
       
    }
    public class VideoHelpEntity
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string VideoLink { get; set; }
        public string MobileVideoLink { get; set; }
        public int Status { get; set; }
    }
}