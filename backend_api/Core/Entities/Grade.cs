namespace CourseRegistration.Core.Entities
{
    public class Grade
    {
        public Guid GradeID { get; set; }

        public Guid StudentID { get; set; }

        public int CourseID { get; set; }

        public string? Semester { get; set; }

        public float Score { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }

    public class GradeResult
    {
        public Guid GradeID { get; set; }

        public Guid StudentID { get; set; }

        public string? StudentCode { get; set; }

        public string? FullName { get; set; }

        public string? Class { get; set; }

        public int CourseID { get; set; }

        public string? CourseCode { get; set; }

        public int Credit { get; set; }

        public string? CourseName { get; set; }

        public float Score { get; set; }
    }

    public class SemesterGrade
    {
        public string? Semester { get; set; }

        public List<GradeResult>? Grades { get; set; }
    }


}
