namespace LeThanhThan_K2023_ThiGk.Dtos.Enrollment
{
    public class EnrollmentConfirmedRequest:EnrollmentCreateRequest
    {
        public Guid Id { get; set; }
        public bool Confirmed { get; set; } = false;
    }
}
