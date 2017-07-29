namespace Tasker.Common.Core.Domain
{
    internal class AggregateDescriptor
    {
        public AggregateRoot Aggregate { get; set; }
        public int Version { get; set; }
    }
}
