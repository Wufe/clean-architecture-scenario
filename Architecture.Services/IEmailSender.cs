using System.Threading.Tasks;

namespace Architecture.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
