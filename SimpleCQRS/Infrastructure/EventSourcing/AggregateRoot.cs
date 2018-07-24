using System;
using System.Collections.Generic;

namespace SimpleCQRS
{
    public abstract class AggregateRoot
    {
        public abstract Guid Id { get; }
        public int Version { get; internal set; }
        private readonly List<Event> _changes = new List<Event>();
        
        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void SourceFromEvents(IEnumerable<Event> history)
        {
            foreach (var e in history)
            {
                ApplyEvent(e);
                Version = e.Version;
            }            
        }

        protected void ApplyChange(Event @event)
        {
            ApplyEvent(@event);
            _changes.Add(@event);
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void ApplyEvent(Event @event)
        {
            this.AsDynamic().Apply(@event);
        }
    }

}
