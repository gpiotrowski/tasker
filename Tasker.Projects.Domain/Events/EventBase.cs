﻿using System;
using Tasker.Common.Core.Events;

namespace Tasker.Projects.Domain.Events
{
    public abstract class EventBase : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
