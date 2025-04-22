namespace LeThanhThan_K2023_ThiGk.Entity
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public virtual List<EnrollmentEntity> Enrollments { get; set; }
    }
}
