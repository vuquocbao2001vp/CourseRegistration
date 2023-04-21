namespace CourseRegistration.Core.Interfaces.Service
{
    public interface IBaseService<Entity>
    {
        /// <summary>
        /// Lấy tất cả dữ liệu trong bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        IEnumerable<Entity> GetAll();

        bool CheckEmptyProperty(object obj);
    }

}
