using System;

namespace SimpleCQRS
{
    public class InventoryItem : AggregateRoot
    {
        private bool _activated;
        private string _name;
        private Guid _id;

        public override Guid Id => _id;

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName cannot be null or empty");
            ApplyChange(new Events.Renamed(newName));
        }

        public void Remove(int count)
        {
            if (count <= 0) throw new InvalidOperationException("cant remove negative count from inventory");
            ApplyChange(new Events.RemovedFromInventory(count));
        }

        public void CheckIn(int count)
        {
            if(count <= 0) throw new InvalidOperationException("must have a count greater than 0 to add to inventory");
            ApplyChange(new Events.CheckedInToInventory(count));
        }

        public void Deactivate()
        {
            if(!_activated) throw new InvalidOperationException("already deactivated");
            ApplyChange(new Events.Deactivated());
        }

        public InventoryItem()
        {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }

        public static InventoryItem Create(Guid id, string name)
        {
            var item = new InventoryItem { _id = id };

            item.ApplyChange(new Events.Created(id, name));
            return item;
        }

        private void Apply(Events.Created e)
        {
            _id = e.Id;
            _activated = true;
            _name = e.Name;
        }

        private void Apply(Events.Deactivated e)
        {
            _activated = false;
        }

        private void Apply(Events.Renamed e)
        {
            _name = e.NewName;
        }

        public class Events
        {
            public class Deactivated : Event
            {
                public Deactivated()
                {
                }
            }

            public class Created : Event
            {
                public readonly Guid Id;
                public readonly string Name;
                public Created(Guid id, string name)
                {
                    Id = id;
                    Name = name;
                }
            }

            public class Renamed : Event
            {
                public readonly string NewName;

                public Renamed(string newName)
                {
                    NewName = newName;
                }
            }

            public class CheckedInToInventory : Event
            {
                public readonly int Count;

                public CheckedInToInventory(int count)
                {
                    Count = count;
                }
            }

            public class RemovedFromInventory : Event
            {
                public readonly int Count;

                public RemovedFromInventory(int count)
                {
                    Count = count;
                }
            }
        }
    }

}
