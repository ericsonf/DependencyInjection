using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class HelloMessageService : IMessage
    {
        public string Show()
        {
            return "Hello Message";
        }
    }
}
