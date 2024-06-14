using Models.DTO;

namespace AndreGarageDependant.Repositories
{
    public class DependantRepository
    {
        private string _connection;

        public DependantRepository(IConfiguration configuration)
        {
            _connection = configuration.GetRequiredSection("ConnectionStrings").GetSection("Database").Value;

        }

        public int Insert(DependantDTO dto)
        {

        }
    }

}
