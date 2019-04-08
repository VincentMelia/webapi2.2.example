using System;
using System.Collections.Generic;
using System.Linq;
using static webapi22.example.data_access.DataAccess;

namespace webapi22.example.validation
{
    public static class MainValidator
    {
        public static List<Tuple<bool, string>> Validate(dynamic d, Guid userId, Guid todoListId)
        {
            var typeofMessageBody = d.GetType();

            //always validate the user
            var userResults = AbstractValidateUser(userId);


            if (typeofMessageBody == typeof(webapi22.example.dtos.DtoClasses.Todo))
            {
                var validatorResults = (Tuple<bool, List<FluentValidation.Results.ValidationFailure>>)ValidatorExtensions.ValidateTodoListItem(d);
                var routeValidatorResults = AbstractValidatePathForList(userId, todoListId);

                ((List<FluentValidation.Results.ValidationFailure>)validatorResults.Item2).ForEach(f =>
                    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));

                routeValidatorResults.Add(userResults[0]);

                routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
                    .Select(i => i.First()).Where(i => !i.Item1).ToList();

                return routeValidatorResults;

            }
            else if (typeofMessageBody == typeof(dtos.DtoClasses.ToDoListWithTodos))
            {
                var validatorResults = ValidatorExtensions.ValidateTodoListWithTodos(d);
                var routeValidatorResults = data_access.DataAccess.AbstractValidatePathForList(userId, todoListId);

                ((List<FluentValidation.Results.ValidationFailure>)validatorResults.Item2).ForEach(f =>
                    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));

                routeValidatorResults.Add(userResults[0]);

                routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
                    .Select(i => i.First()).Where(i => !i.Item1).ToList();

                return routeValidatorResults;
            }

            throw new Exception("Trying to validate a type that doesn't exist.");

        }

        public static List<Tuple<bool, string>> Validate(dynamic d, Guid userId, Guid todoListId, Guid todoItemId)
        {
            var typeofMessageBody = d.GetType();

            //always validate the user
            var userResults = AbstractValidateUser(userId);


            if (typeofMessageBody == typeof(webapi22.example.dtos.DtoClasses.Todo))
            {
                var validatorResults = (Tuple<bool, List<FluentValidation.Results.ValidationFailure>>) ValidatorExtensions.ValidateTodoListItem(d);
                var routeValidatorResults = AbstractValidatePathForListAndItem(userId, todoListId, todoItemId);

                ((List<FluentValidation.Results.ValidationFailure>) validatorResults.Item2).ForEach(f =>
                    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));  

                routeValidatorResults.Add(userResults[0]);

                routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
                    .Select(i => i.First()).Where(i => !i.Item1).ToList();

                return routeValidatorResults;
            }
            else if (typeofMessageBody == typeof(dtos.DtoClasses.ToDoListWithTodos))
            {
                var validatorResults = ValidatorExtensions.ValidateTodoListWithTodos(d);
                var routeValidatorResults = data_access.DataAccess.AbstractValidatePathForList(userId, todoListId);

                ((List<FluentValidation.Results.ValidationFailure>)validatorResults.Item2).ForEach(f =>
                    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));

                routeValidatorResults.Add(userResults[0]);

                routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
                    .Select(i => i.First()).Where(i => !i.Item1).ToList();

                return routeValidatorResults;
            }

            throw new Exception("Trying to validate a type that doesn't exist.");
        }

        public static List<Tuple<bool, string>> Validate(Guid userId, Guid todoListId, Guid todoItemId)
        {
            var userResults = AbstractValidateUser(userId);

            var routeValidatorResults = AbstractValidatePathForListAndItem(userId, todoListId, todoItemId);

            routeValidatorResults.Add(userResults[0]);

            routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
                .Select(i => i.First()).Where(i => !i.Item1).ToList();

            return routeValidatorResults;
        }

        public static List<Tuple<bool, string>> Validate(Guid userId, Guid todoListId)
        {
            //var validatorResults = ValidatorExtensions.ValidateTodoListWithTodos(d);
            //var routeValidatorResults = data_access.DataAccess.AbstractValidatePathForList(userId, todoListId);

            //((List<FluentValidation.Results.ValidationFailure>)validatorResults.Item2).ForEach(f =>
            //    routeValidatorResults.Add(new Tuple<bool, string>(validatorResults.Item1, f.ErrorMessage)));

            //routeValidatorResults.Add(userResults[0]);

            //routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
            //    .Select(i => i.First()).Where(i => !i.Item1).ToList();

            //return routeValidatorResults;

            var userResults = AbstractValidateUser(userId);
            
            var routeValidatorResults = AbstractValidatePathForList(userId, todoListId);

            routeValidatorResults.Add(userResults[0]);

            routeValidatorResults = routeValidatorResults.GroupBy(i => i.Item2)
                .Select(i => i.First()).Where(i => !i.Item1).ToList();

            return routeValidatorResults;
        }

    }
}
