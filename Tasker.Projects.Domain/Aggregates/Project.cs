using Tasker.Common.Core.Domain;

namespace Tasker.Projects.Domain.Aggregates
{
    public class Project : AggregateRoot
    {
        private string _name;

        internal Project(string name)
        {
            _name = name;
        }
    }
}
