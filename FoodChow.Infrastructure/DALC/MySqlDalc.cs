using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FoodChow.Infrastructure.DALC
{
    public class MySqlDalc
    {
        private readonly string _connectionString;

        public MySqlDalc(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySql")
                ?? throw new InvalidOperationException("MySql connection string not configured.");

            // Maps snake_case columns (p_shop_id) → PascalCase properties (ShopId) automatically
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }


        public MySqlConnection CreateConnection() => new MySqlConnection(_connectionString);

        /// <summary>
        /// Execute SP → list of T. Dapper maps columns to properties automatically.
        /// </summary>
        public async Task<IEnumerable<T>> ExecuteSpListAsync<T>(string spName, object? parameters = null)
        {
            await using var conn = CreateConnection();
            return await conn.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> ExecuteQueryAsync(string query, object param)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(query, param);
        }

        /// <summary>
        /// Execute SP → single T or null.
        /// </summary>
        public async Task<T?> ExecuteSpSingleAsync<T>(string spName, object? parameters = null)
        {
            await using var conn = CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Execute SP with no result set (INSERT / UPDATE / DELETE). Returns rows affected.
        /// </summary>
        public async Task<int> ExecuteSpNonQueryAsync(string spName, object? parameters = null)
        {
            await using var conn = CreateConnection();
            return await conn.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Execute SP → first column of first row (scalar).
        /// </summary>
        public async Task<T?> ExecuteSpScalarAsync<T>(string spName, object? parameters = null)
        {
            await using var conn = CreateConnection();

            var result = await conn.QueryFirstOrDefaultAsync<T>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            
            return result;
        }
    }
}
