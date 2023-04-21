using Auth0.ManagementApi.Models.Rules;
using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;
        IStudentService studentService;
        public AuthController(IStudentService _studentService, IConfiguration _configuration)
        {
            configuration = _configuration;
            studentService = _studentService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            if(model != null)
            {
                var checkStudent = studentService.FindStudent(model);
                if(checkStudent != null)
                {
                    checkStudent.StudentMessage = "Login Success";
                    checkStudent.AccessToken = studentService.GetToken(checkStudent);
                    var returnObject = new
                    {
                        info = new
                        {
                            StudentID = checkStudent.StudentID,
                            StudentCode = checkStudent.StudentCode,
                            FullName = checkStudent.FullName,
                            Class = checkStudent.Class,
                        },
                        token = checkStudent.AccessToken,
                    };
                    return Ok(returnObject);
                }
                else
                {
                    return BadRequest("Invalid Student");
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

        
    }
}
