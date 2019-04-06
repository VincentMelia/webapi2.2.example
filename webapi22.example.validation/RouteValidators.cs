using System;
using System.Linq;
using FluentValidation;
using webapi22.example.data_access.in_memory;

namespace webapi22.example.validation
{
    public static class RouteValidators
    {
        public static bool ValidatePath(Guid listId)
        {
            return MockDB._todoList.Where(l => l.TodoListId == listId).ToList().Count > 0;
        }

        public static bool ValidatePath(Guid listId, Guid itemId)
        {
            return MockDB._todoListItems.Where(i => i.TodoListId == listId && i.TodoListItemId == itemId).ToList()
                       .Count > 0;
        }
    }
}
