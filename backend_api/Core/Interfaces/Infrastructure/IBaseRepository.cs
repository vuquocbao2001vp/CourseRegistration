namespace CourseRegistration.Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<Entity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu trong bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        IEnumerable<Entity> GetAll();
    }
}
