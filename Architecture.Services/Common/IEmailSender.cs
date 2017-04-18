using System.Threading.Tasks;

namespace Architecture.Services.Common
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
