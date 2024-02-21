using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDataModel.ViewModel;
using WebService.Implement;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/chitietphieumuon")]
    [ApiController]
    public class ChiTietPhieuMuonController : ControllerBase
    {
        private readonly IChiTietPhieumuonService _chiTietMuonService;
        public ChiTietPhieuMuonController(IChiTietPhieumuonService chiTietPhieumuonService)
        {
            _chiTietMuonService = chiTietPhieumuonService;
        }
        [HttpGet("getbyallsach/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _chiTietMuonService.GetAllSearch(id));
        }
        [HttpPost("addchitietphieumuon")]
        public async Task<IActionResult> Add([FromBody] List<ChiTietPhieuMuonvm> models)
        {
            bool _ischeck = await _chiTietMuonService.AddChiTietPhieuMuon(models);
            return Ok(_ischeck);
        }
        [HttpPost("addonechitietphieumuon")]
        public async Task<IActionResult> AddOne([FromBody] ChiTietPhieuMuonvm models)
        {
            bool _ischeck = await _chiTietMuonService.AddChiTietPhieuMuon(models);
            return Ok(_ischeck);
        }
        [HttpDelete("delechitietphieumuon/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _chiTietMuonService.DeleteChiTietPhieuMuon(id));
        }
        [HttpDelete("delchitietphieumuon/{id}")]
        public async Task<IActionResult> Del(Guid id)
        {
            return Ok(await _chiTietMuonService.DeleteAllChiTietPhieuMuon(id));
        }
    }
}
