using LeThanhThan_K2023_ThiGk.Dtos.Course;
using LeThanhThan_K2023_ThiGk.Dtos.Enrollment;
using LeThanhThan_K2023_ThiGk.Services.Course;
using LeThanhThan_K2023_ThiGk.Services.Enrollment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeThanhThan_K2023_ThiGk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollseservice;
        public EnrollmentController(IEnrollmentService Enroll)
        {
            _enrollseservice = Enroll;
        }
        [HttpGet("GetById/{courseId}")]
        public async Task< IActionResult> GetbyCourseId(Guid courseId)
        {
            try
            {
                var get = await _enrollseservice.GetbyCourseId(courseId);
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(EnrollmentCreateRequest request)
        {
            try
            {
                var get = await _enrollseservice.Create(request);
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Confirm")]
        public async Task<IActionResult> Update(EnrollmentConfirmedRequest request)
        {
            try
            {
                var capnhat = await _enrollseservice.Update(request);
                return Ok(capnhat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _enrollseservice.Delete(id);
                return Ok("Da xoa thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
