using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;

namespace CourseRegistration.Infrastructure.Repository
{
    public class CourseRepository: BaseRepository<Course>, ICourseRepository
    {

        public CourseRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
