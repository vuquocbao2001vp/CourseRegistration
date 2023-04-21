using CourseRegistration.Core.Entities;
using CourseRegistration.Core.Interfaces.Infrastructure;
using Dapper;

namespace CourseRegistration.Infrastructure.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public Student FindStudent(LoginModel model)
        {
            var sql = "SELECT * FROM student WHERE StudentCode = @StudentCode AND Password = @Password LIMIT 1";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@StudentCode", model.StudentCode);
            parameters.Add("@Password", model.Password);
            return connection.QueryFirstOrDefault<Student>(sql, parameters);
        }

        public Object GetStudentTranscript(Guid studentId)
        {
            var storeProc = "Proc_GetStudentTranscript";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@b_StudentID", studentId);
            var grades = connection.Query(storeProc, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            var semesters = grades.GroupBy(g => g.Semester)
                    .Select(g => new SemesterGrade
                    {
                        Semester = g.Key,
                        Grades = g.Select(c => new GradeResult
                        {
                            GradeID = c.GradeID,
                            StudentID = c.StudentID,
                            StudentCode = c.StudentCode,
                            FullName = c.FullName,
                            Class = c.Class,
                            CourseID = c.CourseID,
                            CourseCode = c.CourseCode,
                            CourseName = c.CourseName,
                            Credit = c.Credit,
                            Score = c.Score
                        }).ToList()
                    }).ToList();
            var totalCredit = 0;
            var accumulatedCredit = 0;
            double totalScore = 0;
            double accumulatedScore = 0;
            foreach (var course in grades)
            {
                totalCredit += course.Credit;
                totalScore += (course.Score * course.Credit);
                if(course.Score > 0)
                {
                    accumulatedCredit += course.Credit;
                }
            }
            if(totalCredit > 0)
            {
                accumulatedScore = Math.Round(totalScore / Convert.ToDouble(totalCredit), 2);
            }
            return new
            {
                totalCredit = totalCredit,
                accumulatedCredit = accumulatedCredit,
                accumulatedScore = accumulatedScore,
                transcript = semesters,
            };
        }

        public Object GetStudentSubject(Guid studentId, string? searchKey)
        {
            var storeProc = "Proc_GetStudentSubject";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@b_StudentID", studentId);
            parameters.Add("@b_SearchKey", searchKey);
            var data = connection.Query(storeProc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return new { data = data };
        }

        public Object GetStudentEnrollment(Guid studentId)
        {
            var storeProc = "Proc_GetStudentEnrollment";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@b_StudentID", studentId);
            var data = connection.Query(storeProc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            var listCourse = data.ToList();
            int totalCredit = 0;
            foreach (var course in listCourse)
            {
                totalCredit += course.Credit;
            }
            return new { totalCredit = totalCredit, enrollment = data };
        }

        public int InsertStudentEnrollment(StudentEnrollment studentEnrollment)
        {
            var storeProc = "Proc_InsertStudentEnrollment";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@b_StudentID", studentEnrollment.StudentID);
            parameters.Add("@b_CourseIDs", studentEnrollment.ListCourseId);
            parameters.Add("@b_StatusString", studentEnrollment.ListStatus);
            parameters.Add("@b_Semester", studentEnrollment.Semester);
            var data = connection.Execute(storeProc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return data;
        }

        public int UpdateStudentEnrollment(StudentEnrollment studentEnrollment)
        {
            var storeProc = "Proc_UpdateStudentEnrollment";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@b_StudentID", studentEnrollment.StudentID);
            parameters.Add("@b_CourseIDs", studentEnrollment.ListCourseId);
            parameters.Add("@b_StatusString", studentEnrollment.ListStatus);
            parameters.Add("@b_Semester", studentEnrollment.Semester);
            var data = connection.Execute(storeProc, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return data;
        }

        public int DeleteStudentEnrollment(Guid studentId)
        {
            var sql = "DELETE FROM enrollment WHERE StudentID = @studentId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@studentId", studentId);
            var data = connection.Execute(sql, parameters);
            return data;
        }

    }
}
