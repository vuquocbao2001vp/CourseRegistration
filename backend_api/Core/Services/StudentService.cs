using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;
using CourseRegistration.Core.Interfaces.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseRegistration.Core.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        IConfiguration configuration;
        IStudentRepository studentRepository;
        public StudentService(IStudentRepository _studentRepository, IConfiguration _configuration) : base(_studentRepository)
        {
            studentRepository = _studentRepository;
            configuration = _configuration;
        }

        public Student FindStudent(LoginModel model)
        {
            return studentRepository.FindStudent(model);
        }

        public string GetToken(Student student)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, configuration.GetValue<string>("Jwt:Subject")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("StudentID", student.StudentID.ToString()),
                new Claim("StudentCode", student.StudentCode)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration.GetValue<string>("Jwt:Issuer"),
                configuration.GetValue<string>("Jwt:Audience"),
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signIn);

            string studentToken = new JwtSecurityTokenHandler().WriteToken(token);
            return studentToken;
        }

        public Object GetStudentTranscript(Guid studentId)
        {
            return studentRepository.GetStudentTranscript(studentId);
        }

        public Object GetStudentEnrollment(Guid studentId)
        {
            return studentRepository.GetStudentEnrollment(studentId);
        }

        public Object GetStudentSubject(Guid studentId, string? searchKey)
        {
            return studentRepository.GetStudentSubject(studentId, searchKey);
        }

        public int InsertStudentEnrollment(StudentEnrollment studentEnrollment)
        {
            return studentRepository.InsertStudentEnrollment(studentEnrollment);
        }

        public int UpdateStudentEnrollment(StudentEnrollment studentEnrollment)
        {
            return studentRepository.UpdateStudentEnrollment(studentEnrollment);
        }

        public int DeleteStudentEnrollment(Guid studentId)
        {
            return studentRepository.DeleteStudentEnrollment(studentId);
        }
    }
}
