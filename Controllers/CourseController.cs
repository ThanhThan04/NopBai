using LeThanhThan_K2023_ThiGk.Dtos.Course;
using LeThanhThan_K2023_ThiGk.Services.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeThanhThan_K2023_ThiGk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseservice;
        public CourseController (ICourseService courseservice)
        {
            _courseservice = courseservice;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getall = await _courseservice.GetAll();
            return Ok(getall);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var get = await _courseservice.Get(id);
                 return Ok(get);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CourseCreateRequest request)
        {
            try
            {
                var get = await _courseservice.Create(request);
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public async  Task<IActionResult> Update(CourseUpdate request)
        {
            try
            {
                var capnhat = await _courseservice.Update(request);
                    return Ok(capnhat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                 await _courseservice.Delete(Id);
                return Ok("Da xoa thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
