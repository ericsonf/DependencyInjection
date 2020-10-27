using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class ErrorMessageService : IMessage
    {
        public string Show()
        {
            return "Error Message";
        }
    }
}
