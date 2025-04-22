using LeThanhThan_K2023_ThiGk.Data;
using LeThanhThan_K2023_ThiGk.Dtos.Course;
using LeThanhThan_K2023_ThiGk.Entity;
using Microsoft.EntityFrameworkCore;

namespace LeThanhThan_K2023_ThiGk.Services.Course
{
    public class CourseSevice : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseSevice(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(CourseCreateRequest request)
        {
            var create = await _context.Courses.FirstOrDefaultAsync(c=>c.Title == request.Title);
            if (create != null)
            {
                throw new Exception("khoa hoc da ton tai");

            }
            var them = new CourseEntity
            {
             Id = Guid.NewGuid(),
             Title= request.Title,
             Description = request.Description,
             StartDate = DateTime.Now,
            };
            await _context.AddAsync(them);
            _context.SaveChanges();
            return them.Id;
        
        }


        public async Task Delete(Guid id)
        {
            var xoa = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

             if (xoa == null)
             {
                throw new Exception("khong tim thay nhan vien");
             }
                _context.Courses.Remove(xoa);
              await _context.SaveChangesAsync();

        }

        public async Task<CourseEntity> Get(Guid id)
        {
           var lay1 = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if(lay1 == null)
            {
                throw new Exception("khong tim thay khoa hoc");
            }
            return lay1;
        }

        public async Task<List<CourseEntity>> GetAll()
        {
            var getall = await _context.Courses.ToListAsync();
            return getall;
        }

        public async Task<Guid> Update(CourseUpdate request)
        {
            var update = await _context.Courses.FirstOrDefaultAsync(u=>u.Id == request.Id);
            if(update == null)
            {
                throw new Exception("khong tim thay khoa hoc");
            }
           update.Title = request.Title;
            update.Description = request.Description;
            update.StartDate = DateTime.Now;
            
             _context.Courses.Update(update);
            await _context.SaveChangesAsync();
            return update.Id;
        }
    }
}
