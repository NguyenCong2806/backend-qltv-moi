using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Implement;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/nhaxuatban")]
    public class NhaXuatBanController : BaseController
    {
        private readonly INhaXuatBanService _nhaXuatBanService;

        public NhaXuatBanController(INhaXuatBanService nhaXuatBanService)
        {
            _nhaXuatBanService = nhaXuatBanService;
        }

        [HttpGet("getallnhaxuatban")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            return Ok(await _nhaXuatBanService.GetAllNhaXuatBan(searchParameters));
        }
        [HttpGet("getnhaxuatbanselect")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _nhaXuatBanService.GetAllNhaXuatBan());
        }

        [HttpGet("getbynhaxuatban/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _nhaXuatBanService.GetNhaXuatBan(id));
        }

        [HttpPost("addnhaxuatban")]
        public async Task<IActionResult> Add([FromBody] NhaXuatBanvm model)
        {
            return Ok(await _nhaXuatBanService.AddNhaXuatBan(model));
        }

        [HttpPut("editnhaxuatban")]
        public async Task<IActionResult> Edit([FromBody] NhaXuatBanvm model)
        {
            return Ok(await _nhaXuatBanService.UpdateNhaXuatBan(model));
        }

        [HttpDelete("delnhaxuatban/{id}")]
        public async Task<IActionResult> Del(int id)
        {
            return Ok(await _nhaXuatBanService.DeleteNhaXuatBan(id));
        }
    }
}
