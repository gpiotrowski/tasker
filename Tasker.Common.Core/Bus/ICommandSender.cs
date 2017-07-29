using System.Threading.Tasks;
using Tasker.Common.Core.Commands;

namespace Tasker.Common.Core.Bus
{
    public interface ICommandSender<T> where T : ICommand
    {
        void Send(T command);
    }
}
