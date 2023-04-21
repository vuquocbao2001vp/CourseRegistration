using Dapper;
using MySqlConnector;

namespace CourseRegistration.Infrastructure.Repository
{
    public class BaseRepository<Entity>: IDisposable
    {
        protected MySqlConnection connection;
        public BaseRepository(IConfiguration configuration)
        {
            connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        // Đóng kết nối
        public void Dispose()
        {
            connection.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Lấy tất cả dữ liệu trong bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        public IEnumerable<Entity> GetAll()
        {
            var entity = typeof(Entity).Name.ToLower();
            var sql = $"SELECT * FROM {entity}";
            var data = connection.Query<Entity>(sql);
            return data;
        }
    }
}
