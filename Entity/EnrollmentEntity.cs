namespace LeThanhThan_K2023_ThiGk.Entity
{
    public class EnrollmentEntity
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string StudentName { get; set; }
        public string EnrollCode { get; set; }
        public bool Confirmed { get; set; } = false;
        public virtual CourseEntity Course { get; set; }
    }
}
