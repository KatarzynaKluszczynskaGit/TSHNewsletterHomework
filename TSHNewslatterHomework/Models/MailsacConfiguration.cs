
namespace TSHNewsletterHomework.Models
{
    public class MailSacConfiguration
    {
        public string MailsacBaseEndpoint { get; set; }
        public string MailsacKey { get; set; }
        public string EmailAddress { get; set; }
        public string GetAllMessagesEndpoint { get; set; }
        public string MessagesCountEndpoint { get; set; }
        public string GetMessageBodyEndpoint { get; set; }
    }
}
