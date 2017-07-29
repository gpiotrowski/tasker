using Tasker.Common.Core.Bus;
using Tasker.Common.Core.Domain;
using Tasker.Common.Core.Events;

namespace Tasker.Common.Core.Infrastructure
{
    internal static class PrivateReflectionDynamicObjectExtensions
    {
        public static dynamic AsDynamic(this AggregateRoot o)
        {
            return new PrivateReflectionDynamicObject { RealObject = o };
        }
    }

    public static class PublicReflectionDynamicObjectExtensions
    {
        public static dynamic AsDynamic(this IEventBus o)
        {
            return new PrivateReflectionDynamicObject { RealObject = o };
        }
    }
}
