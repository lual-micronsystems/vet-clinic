using vet_clinic.Domain.Common;
using vet_clinic.Domain.Entities;

namespace vet_clinic.Domain.Events
{
    public class TodoItemCreatedEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
