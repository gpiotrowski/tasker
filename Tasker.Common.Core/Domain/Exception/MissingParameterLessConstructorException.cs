using System;

namespace Tasker.Common.Core.Domain.Exception
{
    public class MissingParameterLessConstructorException : System.Exception
    {
        public MissingParameterLessConstructorException(Type type)
        : base($"{type.FullName} has no constructor without paramerters. This can be either public or private")
        { }
    }
}
