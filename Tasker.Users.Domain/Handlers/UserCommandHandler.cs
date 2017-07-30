using Tasker.Common.Core.Domain;
using Tasker.Users.Domain.Commands;
using Tasker.Users.Domain.Factories;

namespace Tasker.Users.Domain.Handlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly ISession _session;
        private readonly IUserFactory _userFactory;

        public UserCommandHandler(ISession session, IUserFactory userFactory)
        {
            _session = session;
            _userFactory = userFactory;
        }

        public void Handle(CreateUserCommand message)
        {
            var user = _userFactory.CreateUser(message.UserName);
            _session.Add(user);
            _session.Commit();
        }
    }
}
