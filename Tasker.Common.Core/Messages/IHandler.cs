using System.Threading.Tasks;

namespace Tasker.Common.Core.Messages
{
    public interface IHandler<T> where T : IMessage
    {
        void Handle(T message);
    }
}
