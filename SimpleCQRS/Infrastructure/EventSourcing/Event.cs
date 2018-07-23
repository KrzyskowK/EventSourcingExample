using System;

namespace SimpleCQRS
{
    public class Event : Message
    {
        public Guid AggregateId;

        public int Version;
    }
}

