using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;
using CourseRegistration.Core.Interfaces.Service;

namespace CourseRegistration.Core.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        IGradeRepository gradeRepository;
        public GradeService(IGradeRepository _gradeRepository) : base(_gradeRepository)
        {
            gradeRepository = _gradeRepository;
        }
    }
}
