using System;

namespace Tasker.Projects.Application.Exceptions
{
    public class UserNotExistException : Exception
    {
        public UserNotExistException(Guid userId) : base($"User not exist - id {userId}")
        {
            
        }
    }
}
