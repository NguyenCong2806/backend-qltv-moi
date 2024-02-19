using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http.Headers;

namespace Webapi.Configuration
{
    public class FileServer : IFileServer
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public FileServer(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public bool DeleteFile(string filename)
        {
            var folderName = Path.Combine("StaticFiles");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, filename);

            if (Directory.Exists(Path.GetDirectoryName(fullPath)))
            {
                try
                {
                    File.Delete(fullPath);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
            return false;
        }

        public async Task<FileContentResult> DownloadFile(string filename)
        {
            try
            {
                var folderName = Path.Combine("StaticFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fullPath = Path.Combine(pathToSave, filename);

                var mimeType = this.GetMimeType(filename);

                byte[] bytes = null;
                if (Directory.Exists(Path.GetDirectoryName(fullPath)))
                {
                    bytes = await File.ReadAllBytesAsync(fullPath);
                }
                else
                {
                    // Code to handle if file is not present
                }

                return new FileContentResult(bytes, mimeType)
                {
                    FileDownloadName = filename
                };
            }
            catch (Exception ex)
            {
            }
            throw new NotImplementedException();
        }

        public async Task<bool> FileExistsAsync(IFormFile file)
        {
            return await Task.Run(() => File.Exists(file.FileName));
        }

        public async Task<bool> FileExistsAsync(string path)
        {
            return await Task.Run(() => File.Exists(path));
        }

        public Task<double> FileSizeAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadMultipleFileAsync(IEnumerable<IFormFile> files, double filesize)
        {
            try
            {
                var folderName = Path.Combine("StaticFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                    if (!File.Exists(fullPath) && file.Length <= filesize)
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UploadSingleFileAsync(IFormFile file, double filesize)
        {
            try
            {
                var folderName = Path.Combine("StaticFiles");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                if (Directory.Exists(Path.GetDirectoryName(fullPath))
                    && file.Length <= filesize)
                {
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<string>> GetFile()
        {
            List<string> files = new List<string>();
            try
            {
                var folderName = Path.Combine("StaticFiles");
                var pathToRead = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                files = Directory.EnumerateFiles(pathToRead)
                    .Where(IsAPhotoFile)
                    .Select(fullPath => folderName + "/" + Path.GetFileName(fullPath)).ToList();

                return await Task.Run(() => files);
            }
            catch (Exception ex)
            {
                files.Add(ex.Message);
            }
            return files;
        }

        private bool IsAPhotoFile(string fileName)
        {
            return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
        }

        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}