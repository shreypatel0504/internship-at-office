namespace FoodChow.Domain.Entities
{
    public class MarketingEntity
    {
        public long Id { get; set; }
        public long ShopId { get; set; }

        public string FromEmail { get; set; }
        public string FromName { get; set; }

        public string ToEmail { get; set; }
        public string ToName { get; set; }

        public string Message { get; set; }
        public string Attachment { get; set; }
        public string Subject { get; set; }

        public long DebitId { get; set; }
        public int IsSubscribe { get; set; }
    }
    public class MarketingMaterialEntity
    {
        public long Id { get; set; }
        public long MarketingId { get; set; }
        public string MaterialName { get; set; }
        public string FilePath { get; set; }
        public int Status { get; set; }
    }
    public class BannerEntity
    {
        public long Id { get; set; }
        public long ShopId { get; set; }
        public string Title { get; set; }
        public string BannerImage { get; set; }
        public int Status { get; set; }
    }
  
    public class LinktreeEntity
    {
        public long Id { get; set; }
        public string ShopId { get; set; }
        public string Label { get; set; }
        public string LinkUrl { get; set; }
        public int Status { get; set; }
    }
    
    public class SeoEntity
    {
        public long ShopId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class WidgetEntity
    {
        public long ShopId { get; set; }
        public string ColorPicker { get; set; }
        public string WebsiteColor { get; set; }
    }
}