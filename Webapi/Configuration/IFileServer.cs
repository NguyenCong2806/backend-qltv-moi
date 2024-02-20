using Microsoft.AspNetCore.Mvc;

namespace Webapi.Configuration
{
    public interface IFileServer
    {
        public Task<bool> FileExistsAsync(IFormFile file);
        public Task<bool> EditFile(IFormFile file, string path);
        public Task<double> FileSizeAsync(IFormFile file);
        public Task<bool> FileExistsAsync(string path);
        public Task<bool> UploadSingleFileAsync(IFormFile file,double filesize);
        public Task<bool> UploadMultipleFileAsync(IEnumerable<IFormFile> files,double filesize);
        public Task<FileContentResult> DownloadFile(string path);
        public bool DeleteFile(string path);
        public Task<List<string>> GetFile();

    }
}
