using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;
using CourseRegistration.Core.Interfaces.Service;

namespace CourseRegistration.Core.Services
{
    public class EnrollmentService : BaseService<Enrollment>, IEnrollmentService
    {
        IEnrollmentRepository enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository _enrollmentRepository) : base(_enrollmentRepository)
        {
            enrollmentRepository = _enrollmentRepository;
        }
    }
}
