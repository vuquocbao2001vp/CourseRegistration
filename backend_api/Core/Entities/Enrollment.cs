namespace CourseRegistration.Core.Entities
{
    public class Enrollment
    {
        public Guid EnrollmentID { get; set; }

        public Guid StudentID { get; set; }

        public int CourseID { get; set; }

        public string? Semester { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
