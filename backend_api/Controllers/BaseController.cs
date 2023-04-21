using CourseRegistration.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity> : ControllerBase
    {
        IBaseService<Entity> service;
        
        public BaseController(IBaseService<Entity> _service)
        {
            service = _service;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu trong bảng
        /// </summary>
        /// <returns>Danh sách toàn bộ bản ghi</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = service.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
