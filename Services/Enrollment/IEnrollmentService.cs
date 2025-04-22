using LeThanhThan_K2023_ThiGk.Dtos.Enrollment;
using LeThanhThan_K2023_ThiGk.Entity;

namespace LeThanhThan_K2023_ThiGk.Services.Enrollment
{
    public interface IEnrollmentService
    {
        Task<List<EnrollmentEntity>>GetbyCourseId(Guid courseId);
        Task<EnrollmentEntity> Create (EnrollmentCreateRequest request);
        Task<EnrollmentEntity> Update(EnrollmentConfirmedRequest request);
        Task<bool> Delete(Guid id);
    }
}
