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
    public class StudentsController : BaseController<Student>
    {
        IStudentService studentService;

        public StudentsController(IStudentService _studentService) : base(_studentService)
        {
            studentService = _studentService;
        }

        [HttpGet("student-transcript/{id}")]
        public IActionResult GetStudentTranscript(Guid id)
        {
            try
            {
                var data = studentService.GetStudentTranscript(id);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet("student-subject")]
        public IActionResult GetStudentSubject(Guid id, string? searchKey)
        {
            try
            {
                var data = studentService.GetStudentSubject(id, searchKey);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("student-enrollment/{id}")]
        public IActionResult GetStudentEnrollment(Guid id)
        {
            try
            {
                var data = studentService.GetStudentEnrollment(id);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("student-enrollment")]
        public IActionResult InsertStudentEnrollment(StudentEnrollment studentEnrollment)
        {
            try
            {
                if (studentService.CheckEmptyProperty(studentEnrollment))
                {
                    return BadRequest("Empty or null property body request");
                } 
                else
                {
                    var data = studentService.InsertStudentEnrollment(studentEnrollment);
                    return StatusCode(201, data);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut("student-enrollment")]
        public IActionResult UpdateStudentEnrollment(StudentEnrollment studentEnrollment)
        {
            try
            {
                if (studentService.CheckEmptyProperty(studentEnrollment))
                {
                    return BadRequest("Empty or null property body request");
                }
                else
                {
                    var data = studentService.UpdateStudentEnrollment(studentEnrollment);
                    return StatusCode(201, data);
                }
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete("student-enrollment/{id}")]
        public IActionResult DeleteStudentEnrollment(Guid id)
        {
            try
            {
                var data = studentService.DeleteStudentEnrollment(id);
                return StatusCode(201, data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
