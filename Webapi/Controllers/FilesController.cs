using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapi.Configuration;

namespace Webapi.Controllers
{
    [Route("api/files")]
    public class FilesController : BaseController
    {
        private readonly IFileServer _fileServer;

        public FilesController(IFileServer fileServer)
        {
            _fileServer = fileServer;
        }

        [AllowAnonymous]
        [HttpGet("getfiles")]
        public async Task<IActionResult> GetFile()
        {
            return Ok(await _fileServer.GetFile());
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            return Ok(await _fileServer.UploadSingleFileAsync(file, 20000000));
        }

        [HttpPut("editfile")]
        public async Task<IActionResult> EditFile(IFormFile file, string filename)
        {
            var _isdel = await _fileServer.EditFile(file, filename);
            return Ok(_isdel);
        }

        [HttpPost("delete/{filename}")]
        public IActionResult DeleteFile(string filename)
        {
            return Ok(_fileServer.DeleteFile(filename));
        }

        [HttpGet("dowload/{filename}")]
        public async Task<IActionResult> Dowloadfile(string filename)
        {
            return Ok(await _fileServer.DownloadFile(filename));
        }
    }
}