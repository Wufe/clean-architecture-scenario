using System.Threading.Tasks;

namespace Architecture.Services.Common
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
