namespace LeThanhThan_K2023_ThiGk.Dtos.Enrollment
{
    public class EnrollmentCreateRequest
    {
        public Guid CourseId { get; set; }
        public string StudentName { get; set; }
        public string EnrollCode { get; set; }
    }
}
