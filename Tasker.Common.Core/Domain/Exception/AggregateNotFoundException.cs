﻿using System;

namespace Tasker.Common.Core.Domain.Exception
{
    public class AggregateNotFoundException : System.Exception
    {
        public AggregateNotFoundException(Type t, Guid id)
            : base($"Aggregate {id} of type {t.FullName} was not found")
        { }
    }
}
