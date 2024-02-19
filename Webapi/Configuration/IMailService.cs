using WebDataModel.ViewModel;

namespace Webapi.Configuration
{
    public interface IMailService
    {
        public Task<bool> SendMail(MailData mailData);
    }
}
