using System.Threading.Tasks;

namespace Architecture.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
