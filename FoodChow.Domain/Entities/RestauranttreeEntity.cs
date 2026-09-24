namespace FoodChow.Domain.Entities
{
    public class RestaurantTreeEntity
    {
        public long Id { get; set; }
        public string ShopId { get; set; }
        public string Label { get; set; }
        public string IconClass { get; set; }
        public string IconPath { get; set; }
        public string LinkUrl { get; set; }
        public long DisplayPosition { get; set; }
        public int Status { get; set; }
        public int DefaultSection { get; set; }
    }

    public class RestaurantOverviewEntity
    {
        public int Id { get; set; }
        public long ShopId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string RestaurantStory { get; set; }
    }

    public class ShopOfferDealEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
    public class RecommendedItemEntity
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int CategoryId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int Position { get; set; }
        public int Status { get; set; }
    }

    public class UserWhatsAppSubscribeEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string MobileNo { get; set; }
        public string CustName { get; set; }
        public string CountryCode { get; set; }
    }

    public class FoodShopFaqEntity
    {
        public int Id { get; set; }

        public string ShopId { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public int FaqCategoryId { get; set; }

        public int Status { get; set; }
    }

    public class FaqCategoryEntity
    {
        public int Id { get; set; }
        public string FaqCategory { get; set; }
    }

    public class TestimonialEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Status { get; set; }
    }
    public class FoodFeedbackEntity
    {
        public long Id { get; set; }
        public string ShopId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Experience { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
    public class RestaurantJobEntity
    {
        public int Id { get; set; }
        public string ShopId { get; set; }
        public int CategoryId { get; set; }
        public int NoOfPosition { get; set; }
        public int ExperienceFlag { get; set; }
        public string StartSalary { get; set; }
        public string EndSalary { get; set; }
        public string Skills { get; set; }
        public string Description { get; set; }
    }
   
}