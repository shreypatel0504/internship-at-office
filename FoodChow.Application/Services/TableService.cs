using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class TableService
    {
        private readonly ITableRepository _repo;

        public TableService(ITableRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<TableEntity>> GetAll(long shopId)
        => _repo.GetAllTables(shopId);

        public Task UpdateStatus(long id, int status)
            => _repo.UpdateTableStatus(id, status);

        public Task<IEnumerable<dynamic>> GetWithCategory(long shopId)
            => _repo.GetTableWithCategory(shopId);

        public Task<IEnumerable<dynamic>> GetCategories(long shopId)
     => _repo.GetCategories(shopId);

        public Task Delete(long id,int shopId)
            => _repo.DeleteTable(id,shopId);

        public Task<long> Add(TableEntity t) => _repo.Add(t);
        public Task Update(TableEntity t) => _repo.Update(t);
        public Task Delete(long id, long shopId) => _repo.Delete(id, shopId);

        public Task<IEnumerable<ShopDineInTableEntity>> GetShopTables(long shopId)
    => _repo.GetShopTables(shopId);

        public Task AddShopTable(ShopDineInTableEntity model)
            => _repo.AddShopTable(model);

        public Task UpdateShopTable(ShopDineInTableEntity model)
            => _repo.UpdateShopTable(model);

        public Task DeleteShopTable(long id)
            => _repo.DeleteShopTable(id);

        //public Task<IEnumerable<TableEntity>> GetAll(long shopid)
        //{
        //    return _repo.GetAll(shopid);
        //}
        public Task<long> InsertPosTableCategory(string categoryName, int status, long shopId)
    => _repo.InsertPosTableCategory(categoryName, status, shopId);

        public Task<long> InsertPosTableEntryCategoryWise(
            long categoryId,
            string tableName,
            int status,
            string noOfPeople,
            long shopId,
            string businessType)
            => _repo.InsertPosTableEntryCategoryWise(
                categoryId,
                tableName,
                status,
                noOfPeople,
                shopId,
                businessType);

        public Task UpdatePosTableCategoryName(long id, string categoryName)
            => _repo.UpdatePosTableCategoryName(id, categoryName);

        public Task UpdatePosTableEntry(
            long id,
            long categoryId,
            string tableName,
            int status,
            string noOfPeople,
            string businessType)
            => _repo.UpdatePosTableEntry(
                id,
                categoryId,
                tableName,
                status,
                noOfPeople,
                businessType);

        public Task DeletePosTableCategory(long id)
            => _repo.DeletePosTableCategory(id);

        public Task DeletePosTableEntry(long id)
            => _repo.DeletePosTableEntry(id);

        public Task<dynamic> GetAllTableListWithCategories(long shopId)
            => _repo.GetAllTableListWithCategories(shopId);

        public Task<dynamic> GetTableCategoryList(long shopId)
            => _repo.GetTableCategoryList(shopId);

        public Task AddTablesInBulk(long shopId, string prefix, int count, int noOfSeat)
            => _repo.AddTablesInBulk(shopId, prefix, count, noOfSeat);
    }

}