using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/phieumuon")]
    public class PhieuMuonController : BaseController
    {
        private readonly IPhieuMuonService _PhieuMuonService;
        public PhieuMuonController(IPhieuMuonService PhieuMuonService)
        {
            _PhieuMuonService = PhieuMuonService;
        }

        [HttpGet("getPhieuMuon")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            return Ok(await _PhieuMuonService.GetAllPhieuMuon(searchParameters));
        }

        [HttpGet("getsearch/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _PhieuMuonService.GetAllSearch(name));
        }

        [HttpGet("getbyPhieuMuon/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _PhieuMuonService.GetPhieuMuon(id));
        }

        [HttpPost("addPhieuMuon")]
        public async Task<IActionResult> Add([FromBody] PhieuMuonvm model)
        {
            bool _ischeck = false;
            _ischeck = await _PhieuMuonService.AddPhieuMuon(model);
            return Ok(_ischeck);
        }

        [HttpPut("editPhieuMuon")]
        public async Task<IActionResult> Edit([FromBody] PhieuMuonvm model)
        {
            return Ok(await _PhieuMuonService.UpdatePhieuMuon(model));
        }

        [HttpDelete("delPhieuMuon/{id}")]
        public async Task<IActionResult> Del(Guid id)
        {
            return Ok(await _PhieuMuonService.DeletePhieuMuon(id));
        }
    }
}