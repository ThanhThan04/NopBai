using LeThanhThan_K2023_ThiGk.Dtos.Course;
using LeThanhThan_K2023_ThiGk.Entity;

namespace LeThanhThan_K2023_ThiGk.Services.Course
{
    public interface ICourseService
    {
        // lay danh sach khoa hoc
        Task<List<CourseEntity>> GetAll();
        //lay thong tin khoa hoc
        Task<CourseEntity> Get(Guid id);
        // them khoa hhoc
        Task<Guid> Create(CourseCreateRequest request);
        //cap nhat khoa hoc
        Task<Guid> Update(CourseUpdate request);
        // xoa 
        Task Delete(Guid id);
    }
}
