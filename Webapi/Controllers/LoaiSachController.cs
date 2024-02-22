using Microsoft.AspNetCore.Mvc;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/loaisach")]
    public class LoaiSachController : BaseController
    {
        private readonly ILoaiSachService _loaiSachService;

        public LoaiSachController(ILoaiSachService loaiSachService)
        {
            _loaiSachService = loaiSachService;
        }

        [HttpGet("getloaisach")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            return Ok(await _loaiSachService.GetAllLoaiSach(searchParameters));
        }
        [HttpGet("getloaisachselect")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _loaiSachService.GetAllLoaiSach());
        }

        [HttpGet("getbyloaisach/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _loaiSachService.GetLoaiSach(id));
        }

        [HttpPost("addloaisach")]
        public async Task<IActionResult> Add([FromBody] LoaiSachvm model)
        {
            return Ok(await _loaiSachService.AddLoaiSach(model));
        }

        [HttpPut("editloaisach")]
        public async Task<IActionResult> Edit([FromBody] LoaiSachvm model)
        {
            return Ok(await _loaiSachService.UpdateLoaiSach(model));
        }

        [HttpDelete("delloaisach/{id}")]
        public async Task<IActionResult> Del(int id)
        {
            return Ok(await _loaiSachService.DeleteLoaiSach(id));
        }
    }
}