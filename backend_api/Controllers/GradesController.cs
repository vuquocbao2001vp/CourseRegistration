using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : BaseController<Grade>
    {
        IGradeService gradeService;

        public GradesController(IGradeService _gradeService) : base(_gradeService)
        {
            gradeService = _gradeService;
        }
    }
}
