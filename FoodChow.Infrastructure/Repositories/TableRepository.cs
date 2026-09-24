using Dapper;
using System.Data;
using FoodChow.Domain.Entities;
using FoodChow.Application.Interfaces;

using FoodChow.Infrastructure.DALC;
public class TableRepository : ITableRepository
{
    private readonly MySqlDalc _dalc;

    public TableRepository(MySqlDalc dalc)
    {
        _dalc = dalc;
    }

    public async Task<long> Add(TableEntity table)
    {
        var parameters = new DynamicParameters();

        parameters.Add("p_id", dbType: DbType.Int64, direction: ParameterDirection.Output);
        parameters.Add("p_shopid", table.shop_id);
        parameters.Add("p_table_name", table.table_name);
        parameters.Add("p_people", table.no_of_people);
        parameters.Add("p_category_id", table.category_id);
        parameters.Add("p_status", table.status);

        await _dalc.CreateConnection().ExecuteAsync(
            "sp_add_table",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return parameters.Get<long>("p_id");
    }

    public async Task Update(TableEntity table)
    {
        await _dalc.CreateConnection().ExecuteAsync("sp_update_table", new
        {
            p_id = table.id,
            p_table_name = table.table_name,
            p_people = table.no_of_people
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task Delete(long id, long shopId)
    {
        await _dalc.CreateConnection().ExecuteAsync("sp_delete_table", new
        {
            p_id = id,
            p_shop_id = shopId
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<TableEntity>> GetAll(long shopid)
    {
        return await _dalc.CreateConnection().QueryAsync<TableEntity>(
            "sp_get_tables",
            new { p_shopid = shopid },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<TableEntity>> GetAllTables(long shopId)
    {
        return await _dalc.CreateConnection().QueryAsync<TableEntity>(
            "USP_GetAllTableList",
            new { shop_id = shopId },  
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task UpdateTableStatus(long tableId, int status)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "USP_UpdateTableStatusForDineIn",
            new
            {
                id = tableId,
                status = status
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<dynamic>> GetTableWithCategory(long shopId)
    {
        return await _dalc.CreateConnection().QueryAsync(
             "sp_get_pos_table_with_categories",
             new { p_shop_id = shopId },
             commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<dynamic>> GetCategories(long shopId) 
    {
        return await _dalc.CreateConnection().QueryAsync(
            "sp_get_pos_table_categories",
            new { shop_id = shopId },
            commandType: CommandType.StoredProcedure  
        );
    }

    public async Task DeleteTable(long id,int shopId)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "delete_pos_table_entry",
            new { id = id,shop_id=shopId },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<ShopDineInTableEntity>> GetShopTables(long shopId)
    {
        return await _dalc.CreateConnection().QueryAsync<ShopDineInTableEntity>(
            "sp_get_shop_dine_in_tables",
            new { p_shop_id = shopId },
            commandType: CommandType.StoredProcedure
        );
    }
    public async Task AddShopTable(ShopDineInTableEntity model)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "sp_add_shop_dine_in_table",
            new
            {
                p_table_no = model.table_no,
                p_no_of_seat = model.no_of_seat,
                p_shop_id = model.shop_id,
                p_status = model.status
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task UpdateShopTable(ShopDineInTableEntity model)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "sp_update_shop_dine_in_table",
            new
            {
                p_id = model.id,
                p_status = model.status
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task DeleteShopTable(long id)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "sp_delete_shop_dine_in_table",
            new { p_id = id },
            commandType: CommandType.StoredProcedure
        );
    }
    public async Task<long> InsertPosTableCategory(string categoryName, int status, long shopId)
    {
        return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
            "InsertPosTableCategory",
            new
            {
                p_category_name = categoryName,
                p_status = status,
                p_shop_id = shopId
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<long> InsertPosTableEntryCategoryWise(
        long categoryId,
        string tableName,
        int status,
        string noOfPeople,
        long shopId,
        string businessType)
    {
        return await _dalc.CreateConnection().ExecuteScalarAsync<long>(
            "InsertPosTableEntryCategoryWise",
            new
            {
                p_category_id = categoryId,
                p_table_name = tableName,
                p_status = status,
                p_No_of_people = noOfPeople,
                p_shop_id = shopId,
                p_business_type = businessType
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdatePosTableCategoryName(long id, string categoryName)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "UpdatePosTableCategoryName",
            new
            {
                p_id = id,
                p_category_name = categoryName
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task UpdatePosTableEntry(
        long id,
        long categoryId,
        string tableName,
        int status,
        string noOfPeople,
        string businessType)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "UpdatePosTableEntry",
            new
            {
                p_id = id,
                p_category_id = categoryId,
                p_table_name = tableName,
                p_status = status,
                p_No_of_people = noOfPeople,
                p_business_type = businessType
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task DeletePosTableCategory(long id)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "DeletePosTableCategory",
            new { p_id = id },
            commandType: CommandType.StoredProcedure);
    }

    public async Task DeletePosTableEntry(long id)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "DeletePosTableEntry",
            new { p_id = id },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<dynamic> GetAllTableListWithCategories(long shopId)
    {
        return await _dalc.CreateConnection().QueryAsync(
            "GetAllTableListWithCategories",
            new { p_shop_id = shopId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<dynamic> GetTableCategoryList(long shopId)
    {
        return await _dalc.CreateConnection().QueryAsync(
            "GetTableCategoryList",
            new { p_shop_id = shopId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task AddTablesInBulk(long shopId, string prefix, int count, int noOfSeat)
    {
        await _dalc.CreateConnection().ExecuteAsync(
            "addTablesInBulk",
            new
            {
                p_shop_id = shopId,
                p_prefix = prefix,
                p_count = count,
                p_no_of_seat = noOfSeat
            },
            commandType: CommandType.StoredProcedure);
    }


}