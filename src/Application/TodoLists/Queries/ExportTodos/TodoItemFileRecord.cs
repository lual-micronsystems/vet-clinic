using vet_clinic.Application.Common.Mappings;
using vet_clinic.Domain.Entities;

namespace vet_clinic.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
