namespace CourseRegistration.Core.Entities
{
    public class Student
    {
        public Guid StudentID { get; set; }

        public string? StudentCode { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Password { get; set; }

        public string? Class { get; set; }

        public int? Gender { get; set; }
        
        public DateTime? DateOfBirth { get; set; }

        public string? AccessToken { get; set; }

        public string? StudentMessage { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }

    public class LoginModel
    {
        public string? StudentCode { get; set; }

        public string? Password { get; set; }
    }

    public class StudentEnrollment
    {
        public Guid StudentID { get; set; }

        public string? ListCourseId { get; set; }

        public string? ListStatus { get; set; }

        public string? Semester { get; set; }
    }
}
