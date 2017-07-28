using System;
using Tasker.Common.Core.Messages;

namespace Tasker.Common.Core.Events
{
    public interface IEvent : IMessage
    {
        Guid Id { get; set; }
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}
