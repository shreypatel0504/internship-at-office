using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface ITableRepository
    {
        Task<IEnumerable<TableEntity>> GetAll(long shopid);
        Task<long> Add(TableEntity table);
        Task Update(TableEntity table);
        Task Delete(long id, long shopId);
        Task<IEnumerable<TableEntity>> GetAllTables(long shopId);
        Task UpdateTableStatus(long tableId, int status);
        Task<IEnumerable<dynamic>> GetTableWithCategory(long shopId);
        Task<IEnumerable<dynamic>> GetCategories(long shopId);
        Task DeleteTable(long id,int shopId);
        Task<IEnumerable<ShopDineInTableEntity>> GetShopTables(long shopId);
        Task AddShopTable(ShopDineInTableEntity model);
        Task UpdateShopTable(ShopDineInTableEntity model);
        Task DeleteShopTable(long id);
        Task<long> InsertPosTableCategory(string categoryName, int status, long shopId);

        Task<long> InsertPosTableEntryCategoryWise(
            long categoryId,
            string tableName,
            int status,
            string noOfPeople,
            long shopId,
            string businessType);

        Task UpdatePosTableCategoryName(long id, string categoryName);

        Task UpdatePosTableEntry(
            long id,
            long categoryId,
            string tableName,
            int status,
            string noOfPeople,
            string businessType);

        Task DeletePosTableCategory(long id);

        Task DeletePosTableEntry(long id);

        Task<dynamic> GetAllTableListWithCategories(long shopId);

        Task<dynamic> GetTableCategoryList(long shopId);

        Task AddTablesInBulk(long shopId, string prefix, int count, int noOfSeat);

    }
}