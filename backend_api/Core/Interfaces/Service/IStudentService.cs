using CourseRegistration.Core.Entities;

namespace CourseRegistration.Core.Interfaces.Service
{
    public interface IStudentService : IBaseService<Student>
    {
        Student FindStudent(LoginModel model);
        string GetToken(Student student);

        Object GetStudentTranscript(Guid studentId);

        Object GetStudentEnrollment(Guid studentId);

        Object GetStudentSubject(Guid studentId, string? searchKey);

        int InsertStudentEnrollment(StudentEnrollment studentEnrollment);

        int UpdateStudentEnrollment(StudentEnrollment studentEnrollment);

        int DeleteStudentEnrollment(Guid studentId);
    }
}
