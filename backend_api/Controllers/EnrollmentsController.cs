using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : BaseController<Enrollment>
    {
        IEnrollmentService enrollmentService;

        public EnrollmentsController(IEnrollmentService _enrollmentService) : base(_enrollmentService)
        {
            enrollmentService = _enrollmentService;
        }
    }
}
