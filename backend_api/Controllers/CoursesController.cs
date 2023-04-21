using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController<Course>
    {
        ICourseService courseService;

        public CoursesController(ICourseService _courseService): base(_courseService)
        {
            courseService = _courseService;
        }
    }
}
