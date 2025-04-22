using LeThanhThan_K2023_ThiGk.Data;
using LeThanhThan_K2023_ThiGk.Dtos.Enrollment;
using LeThanhThan_K2023_ThiGk.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeThanhThan_K2023_ThiGk.Services.Enrollment
{
    public class EnrollmentService : IEnrollmentService
    { 
        private readonly AppDbContext _enrollmentService;
        public EnrollmentService(AppDbContext enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        public async Task<EnrollmentEntity> Create(EnrollmentCreateRequest request)
        {
            var enroll = new EnrollmentEntity
            {
                Id = Guid.NewGuid(),
                CourseId = request.CourseId,
                StudentName = request.StudentName,
                EnrollCode = Guid.NewGuid().ToString().Substring(0,6),
                Confirmed = false
            };
            await _enrollmentService.AddAsync(enroll);
            await _enrollmentService.SaveChangesAsync();
            return enroll;

        }

        public async Task<bool> Delete(Guid id )
        {
            var xoa = await _enrollmentService.Enroll.FirstOrDefaultAsync(x => x.Id==id);

            if (xoa == null)
            {
                throw new Exception("khong tim thay nhan vien");
            }
            _enrollmentService.Enroll.Remove(xoa);
            await _enrollmentService.SaveChangesAsync();
            return true;
        }

        public async Task<List<EnrollmentEntity>> GetbyCourseId(Guid courseId)
        {
            var lay1 = await _enrollmentService.Enroll.Where(c => c.CourseId == courseId).ToListAsync();
            
           return lay1;
        }

        public async Task<EnrollmentEntity> Update(EnrollmentConfirmedRequest request)
        {
            var capnhat = await _enrollmentService.Enroll.FirstOrDefaultAsync(u => u.Id == request.Id);
            if (capnhat == null)
            {
                throw new Exception("Khong thay ghi danh");
            }
            capnhat.Confirmed= true;
             _enrollmentService.Enroll.Update(capnhat);
            await _enrollmentService.SaveChangesAsync();
            return capnhat;
        }
    }
}
