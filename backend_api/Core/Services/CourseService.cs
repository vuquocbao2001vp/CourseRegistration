using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;
using CourseRegistration.Core.Interfaces.Service;

namespace CourseRegistration.Core.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        ICourseRepository courseRepository;
        public CourseService(ICourseRepository _courseRepository) : base(_courseRepository)
        {
            courseRepository = _courseRepository;
        }
    }
}
