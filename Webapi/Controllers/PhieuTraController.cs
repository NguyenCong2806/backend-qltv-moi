using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/phieutra")]
    public class PhieuTraController : BaseController
    {
        private readonly IPhieuTraService _PhieuTraService;
        public PhieuTraController(IPhieuTraService PhieuTraService)
        {
            _PhieuTraService = PhieuTraService;
        }

        [HttpGet("getPhieuTra")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            return Ok(await _PhieuTraService.GetAllPhieuTra(searchParameters));
        }
        [HttpPost("addPhieuTra")]
        public async Task<IActionResult> Add([FromBody] PhieuTravm model)
        {
            bool _ischeck = false;
            _ischeck = await _PhieuTraService.AddPhieuTra(model);
            return Ok(_ischeck);
        }

        [HttpPut("editPhieuTra")]
        public async Task<IActionResult> Edit([FromBody] PhieuTravm model)
        {
            return Ok(await _PhieuTraService.UpdatePhieuTra(model));
        }

        [HttpDelete("delPhieuTra/{id}")]
        public async Task<IActionResult> Del(Guid id)
        {
            return Ok(await _PhieuTraService.DeletePhieuTra(id));
        }
    }
}
