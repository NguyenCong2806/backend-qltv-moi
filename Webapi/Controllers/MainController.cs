using Microsoft.AspNetCore.Mvc;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Implement;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/main")]
    public class MainController : BaseController
    {
        private readonly IDocGiaService _docGiaService;
        private readonly ISachService _sachService;
        private readonly IPhieuMuonService _PhieuMuonService;
        private readonly IPhieuTraService _PhieuTraService;

        public MainController(IDocGiaService docGiaService, ISachService sachService,
            IPhieuMuonService phieuMuonService, IPhieuTraService phieuTraService)
        {
            _docGiaService = docGiaService;
            _sachService = sachService;
            _PhieuMuonService = phieuMuonService;
            _PhieuTraService = phieuTraService;
        }
        [HttpGet("getmain")]
        public async Task<IActionResult> Get()
        {
            var _data = new mainnumber();
            _data.docgianumber = await _docGiaService.Count();
            _data.sachnumber = await _sachService.Count();
            _data.phieutranumber = await _PhieuTraService.Count();
            _data.phieumuonnumber = await _PhieuMuonService.Count();
            return Ok(_data);
        }
    }
}