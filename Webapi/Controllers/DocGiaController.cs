using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/docgia")]
    [ApiController]
    public class DocGiaController : ControllerBase
    {
        private readonly IDocGiaService _DocGiaService;

        public DocGiaController(IDocGiaService DocGiaService)
        {
            _DocGiaService = DocGiaService;
        }

        [HttpGet("getdocgia")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            return Ok(await _DocGiaService.GetAllDocGia(searchParameters));
        }

        [HttpGet("getbydocgia/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _DocGiaService.GetDocGia(id));
        }

        [HttpPost("adddocgia")]
        public async Task<IActionResult> Add([FromBody] DocGiavm model)
        {
            return Ok(await _DocGiaService.AddDocGia(model));
        }

        [HttpPut("editdocgia")]
        public async Task<IActionResult> Edit([FromBody] DocGiavm model)
        {
            return Ok(await _DocGiaService.UpdateDocGia(model));
        }

        [HttpDelete("deldocgia/{id}")]
        public async Task<IActionResult> Del(Guid id)
        {
            return Ok(await _DocGiaService.DeleteDocGia(id));
        }
    }
}
