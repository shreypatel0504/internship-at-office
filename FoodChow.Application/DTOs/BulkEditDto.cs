namespace FoodChow.Application.DTOs
{
    // ---------- Category ----------
    public class BulkCategoryEditDto
    {
        public long ShopId { get; set; }
        public List<BulkCategoryItemDto> CategoryList { get; set; } = new();
    }
    public class BulkCategoryItemDto
    {
        public long Id { get; set; }
        public string? CateName { get; set; }
    }

    // ---------- Item Price ----------
    public class BulkEditItemDto
    {
        public long ShopId { get; set; }
        public List<BulkItemPriceDto> ItemList { get; set; } = new();
    }
    public class BulkItemPriceDto
    {
        public long ItemId { get; set; }
        public string? ItemName { get; set; }
        public double Price { get; set; }
        public int IsSize { get; set; }
        public List<ItemWithSizeDto> SizeList { get; set; } = new();
    }
    public class ItemWithSizeDto
    {
        public long SizeId { get; set; }
        public string? SizeName { get; set; }
        public double Price { get; set; }
    }

    // ---------- Variants ----------
    public class BulkItemSizeDto
    {
        public long ShopId { get; set; }
        public List<BulkSizeItemDto> SizeList { get; set; } = new();
    }
    public class BulkSizeItemDto
    {
        public long Id { get; set; }
        public string? SizeName { get; set; }
    }

    // ---------- Choices ----------
    public class BulkEditChoicesDto
    {
        public long ShopId { get; set; }
        public List<BulkChoicesListDto> ChoicesList { get; set; } = new();
    }
    public class BulkChoicesListDto
    {
        public long PreferenceId { get; set; }
        public string? PreferenceName { get; set; }
        public object? IsActive { get; set; }
        public object? IsMandatory { get; set; }
        public object? SoldOutFlag { get; set; }
        public List<BulkChoicesOptionsDto> ChoiceOptionsList { get; set; } = new();
    }
    public class BulkChoicesOptionsDto
    {
        public long PreferenceOptionId { get; set; }
        public string? OptionName { get; set; }
        public object? IsActive { get; set; }
        public object? SoldOutFlag { get; set; }
    }

    // ---------- Extra ----------
    public class ExtraStoreDto
    {
        public long ShopId { get; set; }
        public List<ExtraStoreCategoryDto> ExtraCategoryList { get; set; } = new();
    }
    public class ExtraStoreCategoryDto
    {
        public long CustomCatId { get; set; }
        public string? CustomCatName { get; set; }
        public object? Status { get; set; }
        public List<ExtraStoreCategoryOptionDto> ExtraCategoryOptionList { get; set; } = new();
    }
    public class ExtraStoreCategoryOptionDto
    {
        public long IngredientId { get; set; }
        public string? IngredientName { get; set; }
        public object? IsSize { get; set; }
        public object? IsVeg { get; set; }
        public object? Status { get; set; }
        public double Price { get; set; }
        public object? SoldOutFlag { get; set; }
        public List<ExtraStoreCategoryOptionSizeDto> ExtraCategoryOptionSizeList { get; set; } = new();
    }
    public class ExtraStoreCategoryOptionSizeDto
    {
        public long ItemIngredientSizeId { get; set; }
        public long SizeId { get; set; }
        public string? SizeName { get; set; }
        public double Price { get; set; }
        public object? Status { get; set; }
        public object? SoldOutFlag { get; set; }
    }
}