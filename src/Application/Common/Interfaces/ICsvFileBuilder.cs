using vet_clinic.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace vet_clinic.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
