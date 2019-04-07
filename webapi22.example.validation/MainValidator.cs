using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using static webapi22.example.validation.ValidatorExtensions;
using static webapi22.example.validation.RouteValidators;
using webapi22.example.validation;

namespace webapi22.example.validation
{
    public static class MainValidator
    {
        //dynamic t = new Todo();
        //var r = MainValidator.Validate(t);

        //d.GetType() == typeof(webapi22.example.dtos.DtoClasses.Todo)

        public static bool Validate(dynamic d, Guid userId, Guid todoListId, Guid todoItemId)
        {
            var v = d.GetType();

            if (v == typeof(webapi22.example.dtos.DtoClasses.Todo))
            {
                var validatorResults = ValidatorExtensions.ValidateTodoListItem(d);
                var routeValidatorResults = RouteValidators.ValidatePath(todoListId, todoItemId);
            }

            return false;
        }
    }
}
