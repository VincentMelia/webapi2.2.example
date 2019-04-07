using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using webapi22.example.data_access.in_memory;

namespace webapi22.example.validation
{
    public static class RouteValidators
    {
        public static List<Tuple<bool, string>> ValidatePath(Guid userId, Guid listId)
        {
            var result = new List<Tuple<bool, string>>();

            bool exists = MockDB._todoList.Where(l => l.TodoListId == listId && l.UserId == userId).ToList().Count > 0;

            result.Add(new Tuple<bool, string>(exists, !exists ? "Todo list doesn't exist." : string.Empty));
            return result;
        }

        public static List<Tuple<bool, string>> ValidatePath(Guid userId, Guid listId, Guid itemId)
        {
            var validationList = new List<Tuple<bool, string>>();

            var validTodoListResults = ValidatePath(userId, listId);

            bool exists = MockDB._todoListItems
                              .Where(i => i.TodoListId == listId && i.TodoListItemId == itemId &&
                                          i.UserId == userId).ToList()
                              .Count > 0;

            var validTodoItemResults = new Tuple<bool, string>(exists, !exists ? "Todo item doesn't exist." : string.Empty);

            validationList.Add(validTodoListResults[0]);
            validationList.Add(validTodoItemResults);

            return validationList;
            //return MockDB._todoListItems.Where(i => i.TodoListId == listId && i.TodoListItemId == itemId && i.UserId == userId).ToList()
            //           .Count > 0;
        }

    

    }
}
