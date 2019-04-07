using System;
using PostSharp.Aspects;
using Microsoft.AspNetCore.Mvc;

namespace webapi2._2.api
{
    [Serializable]
    public class LogonRequiredAttribute : OnExceptionAspect
    {
        Type type;

        public LogonRequiredAttribute() : this(typeof(ArgumentNullException))
        {
        }

        private LogonRequiredAttribute(Type type) : base()
        {
            this.type = type;
        }

        public override Type GetExceptionType(System.Reflection.MethodBase targetMethod)
        {
            return this.type;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            base.OnException(args);

            if (args.Exception.GetType() == typeof(ArgumentNullException) /*|| args.Exception.GetType() == typeof(InvalidCastException)*/)
            {
                args.FlowBehavior = FlowBehavior.Return;

                args.ReturnValue = /*(ActionResult<ToDoListWithTodos>)*/new BadRequestObjectResult(new Tuple<bool, string>(false, "User not logged on."));
               
            }
        }
    }
}
