using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;

namespace CourseRegistration.Infrastructure.Repository
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
