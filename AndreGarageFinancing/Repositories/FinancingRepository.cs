using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Models.DTO;

namespace AndreGarageFinancing.Repository
{
    public class FinancingRepository
    {
        private string _connectionString;
        public FinancingRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetRequiredSection("ConnectionStrings").GetSection("Database").Value;
            SqlConnection connection = new SqlConnection(_connectionString);
        }

        public int Insert(FinancingDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var rows =connection.Execute(Financing.INSERT, dto);
                connection.Close();
                return rows;
            }
        }

        public async Task<List<FinancingDTO>> GetAll() 
        { 
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var financings = connection.Query<FinancingDTO>(Financing.SELECT).ToList();
                connection.Close();
                return  financings;

            }
        }
        public async Task<FinancingDTO> Get(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var financing = connection.QueryFirstOrDefault<FinancingDTO>(Financing.SELECTBYID, new {Id = id});
                connection.Close();
                return financing;
            }
        }
    }
}
