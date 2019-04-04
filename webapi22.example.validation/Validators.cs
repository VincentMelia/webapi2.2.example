using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using webapi22.example.dtos.DtoClasses;
using webapi22.example.data_access.TypedListClasses;

namespace webapi22.example.validation
{
    public static class ValidatorExtensions
    {
        public static Tuple<bool, List<FluentValidation.Results.ValidationFailure>> ValidateTodoListItemDtoRow(this TodoListItemDtoRow _listItem)
        {
            var validator = new TodoListDtoRowValidator(_listItem).Validate(_listItem);

            var r = new Tuple<bool, List<ValidationFailure>>(validator.IsValid, (List<ValidationFailure>)validator.Errors);

            return r;
        }

        public static Tuple<bool, List<FluentValidation.Results.ValidationFailure>> ValidateTodoListWithTodos(
            this ToDoListWithTodos _todoList)
        {
            var validator = new TodoListWithTodosValidator(_todoList).Validate(_todoList);
            var r = new Tuple<bool, List<ValidationFailure>>(validator.IsValid, (List<ValidationFailure>)validator.Errors);
            return r;
        }
    }


    public class TodoListDtoRowValidator : AbstractValidator<TodoListItemDtoRow>
    {
        internal WeakReference<TodoListItemDtoRow> _todoItem;

        public TodoListDtoRowValidator(TodoListItemDtoRow todoItemToValidate)
        {
            _todoItem = new WeakReference<TodoListItemDtoRow>(todoItemToValidate);

            RuleFor(r => r.TodoListItemSubject).MaximumLength(50).WithMessage("Subject must be less than 50 characters");
        }
    }



    public class TodoListWithTodosValidator : AbstractValidator<ToDoListWithTodos>
    {
        internal WeakReference<ToDoListWithTodos> _todoList;

        public TodoListWithTodosValidator(ToDoListWithTodos todoListToValidate)
        {
            _todoList = new WeakReference<ToDoListWithTodos>(todoListToValidate);

            RuleFor(r => r.TodoListName).MaximumLength(20).WithMessage("List name must be less than 20 characters.");
        }
    }
}
