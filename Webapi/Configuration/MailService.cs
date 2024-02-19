using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using WebDataModel.ViewModel;

namespace Webapi.Configuration
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettingsOptions)
        {
            _mailSettings = mailSettingsOptions.Value;
        }
        public async Task<bool> SendMail(MailData mailData)
        {
            using (MimeMessage emailMessage = new MimeMessage())
            {
                MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SmtpName, _mailSettings.SmtpEmail);

                emailMessage.From.Add(emailFrom);
    
                MailboxAddress emailTo = new MailboxAddress(mailData.ReceiverName, mailData.ReceiverEmail);

                emailMessage.To.Add(emailTo);
                //thêm mail CC và BCC nếu cần
                //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));
                //Gán tiêu đề mail
                emailMessage.Subject = mailData.Title;
  
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = mailData.Body;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                //email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

                using (SmtpClient mailClient = new SmtpClient())
                {
                    //Kết nối tới server smtp.gmail
                    mailClient.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, 
                        MailKit.Security.SecureSocketOptions.StartTls);
                    //đăng nhập
                    mailClient.Authenticate(_mailSettings.SmtpEmail, _mailSettings.SmtpPass);
                    //gửi mail
                    await  mailClient.SendAsync(emailMessage);
                    //ngắt kết nối
                    mailClient.Disconnect(true);
                }
            }
            return true;
        }
    }
}
