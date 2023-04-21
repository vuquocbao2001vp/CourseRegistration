using CourseRegistration.Core.Entities;

namespace CourseRegistration.Core.Interfaces.Infrastructure
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        Student FindStudent(LoginModel model);

        Object GetStudentTranscript(Guid studentId);

        Object GetStudentEnrollment(Guid studentId);

        Object GetStudentSubject(Guid studentId, string? searchKey);

        int InsertStudentEnrollment(StudentEnrollment studentEnrollment);

        int UpdateStudentEnrollment(StudentEnrollment studentEnrollment);

        int DeleteStudentEnrollment(Guid studentId);
    }
}
