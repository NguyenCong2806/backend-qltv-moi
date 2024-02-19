using Microsoft.AspNetCore.Mvc;
using Webapi.Configuration;
using WebDataModel.ViewModel;

namespace Webapi.Controllers
{
    [Route("api/mail")]
    public class MailController : BaseController
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("sendemail")]
        public async Task<IActionResult> SendEmail([FromBody] MailData mailData)
        {
            return Ok(await _mailService.SendMail(mailData));
        }
    }
}