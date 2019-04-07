using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using static webapi22.example.data_access.DataAccess;
using webapi22.example.validation;

namespace webapi22.example.validation
{
    public static class MainValidator
    {

        public static List<Tuple<bool, string>> Validate(dynamic d, Guid userId, Guid todoListId, Guid todoItemId)
        {
            var typeofMessageBody = d.GetType();

            if (typeofMessageBody == typeof(webapi22.example.dtos.DtoClasses.Todo))
            {
                var validatorResults = (Tuple<bool, List<FluentValidation.Results.ValidationFailure>>) ValidatorExtensions.ValidateTodoListItem(d);
                var routeValidatorResults = AbstractValidatePathForListAndItem(userId, todoListId, todoItemId);

                ((List<FluentValidation.Results.ValidationFailure>) validatorResults.Item2).ForEach(f =>
                    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));  //){Item1=  validatorResults.Item1, Item2 = f.ErrorMessage));

                return routeValidatorResults;
            }
            else if (typeofMessageBody == typeof(dtos.DtoClasses.ToDoListWithTodos))
            {
                var validatorResults = ValidatorExtensions.ValidateTodoListWithTodos(d);
                var routeValidatorResults = data_access.DataAccess.AbstractValidatePathForList(userId, todoListId);

                ((List<FluentValidation.Results.ValidationFailure>)validatorResults.Item2).ForEach(f =>
                    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));  //){Item1=  validatorResults.Item1, Item2 = f.ErrorMessage));

                return routeValidatorResults;
            }


            return null;
        }

        public static List<Tuple<bool, string>> Validate(Guid userId, Guid todoListId, Guid todoItemId)
        {
            var routeValidatorResults = AbstractValidatePathForListAndItem(userId, todoListId, todoItemId);

            return routeValidatorResults;
        }

        public static List<Tuple<bool, string>> Validate(Guid userId, Guid todoListId)
        {
            var routeValidatorResults = AbstractValidatePathForList(userId, todoListId);

            return routeValidatorResults;
        }

    }
}
