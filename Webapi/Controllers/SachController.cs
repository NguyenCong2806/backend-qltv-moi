using Microsoft.AspNetCore.Mvc;
using Webapi.Configuration;
using Webapi.Model;
using WebDataModel.BaseClass;
using WebDataModel.ViewModel;
using WebService.Implement;
using WebService.Interface;

namespace Webapi.Controllers
{
    [Route("api/sach")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private readonly ISachService _sachService;
        private readonly IFileServer _fileServer;

        public SachController(ISachService sachService, IFileServer fileServer)
        {
            _sachService = sachService;
            _fileServer = fileServer;
        }

        [HttpGet("getsach")]
        public async Task<IActionResult> Get([FromQuery] SearchParameters searchParameters)
        {
            return Ok(await _sachService.GetAllSach(searchParameters));
        }
        [HttpGet("getsearch/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _sachService.GetAllSearch(name));
        }
        [HttpGet("getbysach/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _sachService.GetSach(id));
        }

        [HttpPost("addsach")]
        public async Task<IActionResult> Add([FromBody] Sachvm model)
        {
            return Ok(await _sachService.AddSach(model));
        }
        [HttpPost("uploadfile")]
        public async Task<IActionResult> Uploadfile(IFormFile file)
        {
            return Ok(await _fileServer.UploadSingleFileAsync(file, 20000000));
        }
        [HttpDelete("delsach/{id}")]
        public async Task<IActionResult> Del(Guid id)
        {
            return Ok(await _sachService.DeleteSach(id));
        }
        [HttpDelete("delete/{filename}")]
        public IActionResult DeleteFile(string filename)
        {
            return Ok(_fileServer.DeleteFile(filename));
        }
        [HttpPut("editsach")]
        public async Task<IActionResult> Edit([FromBody] Sachvm model)
        {
            return Ok(await _sachService.UpdateSach(model));
        }
        [HttpPut("editfile")]
        public async Task<IActionResult> EditFile(IFormFile file, string filename)
        {
            var _isdel = await _fileServer.EditFile(file, filename);
            return Ok(_isdel);
        }
    }
}