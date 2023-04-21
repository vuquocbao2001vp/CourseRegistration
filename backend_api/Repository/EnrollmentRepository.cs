using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;

namespace CourseRegistration.Infrastructure.Repository
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
