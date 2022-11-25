using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Data.Interfaces;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Data.Repository
{
    public class DapperRepositroy<T> : IDapperRepository<T> where T : BaseEntity
    {
        public IConfiguration Configuration { get; }
        public DapperRepositroy(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<int> Add(T entity)
        {
           
            var sql = "Insert into Books (BookName,AuthorName,PageNumber,PublishedDate,CreatedDate,CreatedBy) VALUES (@BookName,@AuthorName,@PageNumber,@PublishedDate,@CreatedDate,@CreatedBy)";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Books WHERE Id = @Id";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            var sql = "SELECT * FROM Books";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(sql);
                return result.ToList();
            }
        }

        public async Task<T> GetById(int id)
        {
            var sql = "SELECT * FROM Books WHERE Id = @Id";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> Update(T entity)
        {
            var sql = "UPDATE Books SET BookName = @BookName, AuthorName = @AuthorName, PageNumber = @PageNumber, PublishedDate = @PublishedDate, ModifiedBy = @ModifiedBy, ModifiedDate = @ModifiedDate WHERE Id = @Id";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
