using CourseRegistration.Core.Interfaces.Infrastructure;

namespace CourseRegistration.Core.Services
{
    public class BaseService<Entity>
    {
        IBaseRepository<Entity> repository;

        public BaseService(IBaseRepository<Entity> _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu trong bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        public IEnumerable<Entity> GetAll()
        {
            var data = repository.GetAll();
            return data;
        }

        public bool CheckEmptyProperty(object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.GetValue(obj) == null || prop.GetValue(obj).ToString() == string.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
