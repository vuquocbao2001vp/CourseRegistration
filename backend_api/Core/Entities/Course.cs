namespace CourseRegistration.Core.Entities
{
    public class Course
    {
        public int  CourseID { get; set; }

        public string? CourseCode { get; set; }

        public int Credit { get; set; }

        public string? CourseName { get; set; }

        public string? Teacher { get; set; }

        public string? Amphitheater { get; set; }

        public string? Schedule { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
