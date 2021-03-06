﻿using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using webapi22.example.dtos.DtoClasses;

namespace webapi22.example.validation
{
    public static class ValidatorExtensions
    {

        //wrapper extension methods for validators below
        public static Tuple<bool, List<FluentValidation.Results.ValidationFailure>> ValidateTodoListItem(this Todo _listItem)
        {
            var validator = new TodoListDtoRowValidator(_listItem).Validate(_listItem);
            var validatorResults = new Tuple<bool, List<ValidationFailure>>(validator.IsValid, (List<ValidationFailure>)validator.Errors);
            return validatorResults;
        }



        public static Tuple<bool, List<FluentValidation.Results.ValidationFailure>> ValidateTodoListWithTodos(
            this ToDoListWithTodos _todoList)
        {
            var validator = new TodoListWithTodosValidator(_todoList).Validate(_todoList);
            var validatorResults = new Tuple<bool, List<ValidationFailure>>(validator.IsValid, (List<ValidationFailure>)validator.Errors);
            return validatorResults;
        }

    }



    //validators//////////////////////////////////////////////////////

    internal class TodoListDtoRowValidator : AbstractValidator<Todo>
    {
        internal WeakReference<Todo> _todoItem;

        public TodoListDtoRowValidator(Todo todoItemToValidate)
        {
            _todoItem = new WeakReference<Todo>(todoItemToValidate);

            RuleFor(r => r.TodoListItemSubject)
                .MaximumLength(50).WithMessage("Subject must be less than 50 characters")
                .MinimumLength(1).WithMessage("Subject is required.")
                .NotNull().WithMessage("Subject is required.")
                .NotEmpty().WithMessage("Subject is required.");
        }
    }



    internal class TodoListWithTodosValidator : AbstractValidator<ToDoListWithTodos>
    {
        internal WeakReference<ToDoListWithTodos> _todoList;

        public TodoListWithTodosValidator(ToDoListWithTodos todoListToValidate)
        {
            _todoList = new WeakReference<ToDoListWithTodos>(todoListToValidate);

            RuleFor(r => r.TodoListName)
                .MaximumLength(20).WithMessage("List name must be less than 20 characters.")
                .MinimumLength(1).WithMessage("List name is required.")
                .NotNull().WithMessage("List name is required.")
                .NotEmpty().WithMessage("List name is required.");
        }
    }
}
