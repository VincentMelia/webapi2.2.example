# webapi2.2.example - Todo List

_updated: SQL Server DAL_
_updated 4/10: global error handling_

## Overview
An example .NET Core solution using WebAPI 2.2 Core, message-based business-layer using friendly DTOs,  an abstract DAL with in-memory and SQL implementations and business-layer route and DTO validation.

## Other Technologies
This example has a simplified authentication process. Since authentication is required, most of the REST services should provide this checking. Since authentication is a cross-cutting concern, this is implemented as a reusable .NET attribute that can decorate either an entire controller or single methods. This is a nice clean way of implementing DRY. Using [PostSharp.NET][1] for this.

The SQL-based DAL implementation is using [LLBLGEN Pro][2] for all data access. All code is auto-generated and allows the type of projections we would normally write, but generates the code for us.
> NOTE: the SQL implementation lightly tested and can be used by switching the DAL flag in appSettings to 1.

DTO validation using [FluentValidation][3], providing declarative business-rule validation.

### Route Structure
Currently using GUIDs for IDs. A route to a list might be:
- http://localhost:5000/todos/{0529460d-ab4c-45c8-9a30-42abeb9a0e0a } - a todo list
- http://localhost:5000/todos/{0529460d-ab4c-45c8-9a30-42abeb9a0e0a }/{d89ee47b-ebbd-4e67-94aa-5560568665a3} - a todo list item

Routes:
- /todos/logon GET. Get a list of users in the system.
- /todos/logon/{user name} ANY. Log on as a user.
- /todos GET. Get the user and their todo lists.
- /todos POST. Create a new todo list for the user.
- /todos/{list guid} GET, PUT, POST, DELETE. Operations on task lists.
- /todos/{list guid}/{list item guid} GET, PUT, POST, DELETE. Operations on task list items.
- /todos/{list guid}/{list item guid}/MarkComplete PUT. Complete a todo item.

### Business-Layer and Validation
The business layer sits behind the API services and consumes/produces the same friendly DTOs that the services do. The web services are essentially a thin wrapper over this layer. As the web services essentially mimic a particular use-case, the business layer can be reused elsewhere and we can be sure to expect the same behavior in any environment.

The validation is based off the same business-layer as the services, with optional extensions on the friendly DTOs. Thus, the same object validation can be used regardless of where the DTOs might be - whether behind the business-layer or in the REST services before an attempt is even made to get to the DAL - enabling DRY wherever possible.

1-3 things need to be validated, depending on the call being made:
- route validation. Check the path of all routes to verify they’re representing something valid in the system.
- DTO validation.
- authenticated user validation.

### Data Access Layer
Pluggable with any data source, just like most repository-type patterns. The difference here is there’s no use of interfaces - it’s all based on abstract functions. 

Here’s the complete abstract DAL specification:



	    public static class DataAccess
	    {
	        public static readonly int dataaccesstype = 0;
	
	        //validators
	        public static Func<Guid, Guid, List<Tuple<bool, string>>> AbstractValidatePathForList;
	        public static Func<Guid, Guid, Guid, List<Tuple<bool, string>>> AbstractValidatePathForListAndItem;
	        public static Func<Guid, List<Tuple<bool, string>>> AbstractValidateUser;
	
	
	        //data access
	        public static Func<List<User>> AbstractGetUsers;
	        public static Func<Guid, Guid, ToDoListWithTodos> AbstractGetTodoList;
	        public static Func<Guid, UserTodoLists> AbstractGetListsForUser;
	        public static Func<Guid, ToDoListWithTodos, ToDoListWithTodos> AbstractCreateTodoList;
	        public static Func<Guid, Guid, ToDoListWithTodos, ToDoListWithTodos> AbstractUpdateTodoList;
	        public static Action<Guid, Guid> AbstractDeleteTodoList;
	        public static Func<Guid, Guid, Todo, Todo> AbstractAddNewTodo;
	        public static Func<Guid, Guid, Guid, Todo> AbstractGetSingleTodoItem;
	        public static Func<Guid, Guid, Guid, Todo, Todo> AbstractUpdateSingleTodoItem;
	        public static Action<Guid, Guid, Guid> AbstractDeleteSingleTodo;

All Func declarations where we can assign a concrete implementation based on a flag:


	if (dataaccesstype == 0)
	            {
	                AbstractValidatePathForList = in_memory.DAL.ValidatePath;
	                AbstractValidatePathForListAndItem = in_memory.DAL.ValidatePath;
	                AbstractValidateUser = in_memory.DAL.ValidateUser;
	
	                AbstractGetUsers = in_memory.DAL.GetUsers;
	                AbstractGetTodoList = in_memory.DAL.GetTodoList;
	                AbstractGetListsForUser = in_memory.DAL.GetListsForUser;
	                AbstractCreateTodoList = in_memory.DAL.CreateTodoList;
	                AbstractUpdateTodoList = in_memory.DAL.UpdateTodoList;
	                AbstractDeleteTodoList = in_memory.DAL.DeleteTodoList;
	                AbstractAddNewTodo = in_memory.DAL.AddNewTodo;
	                AbstractGetSingleTodoItem = in_memory.DAL.GetSingleTodoItem;
	                AbstractUpdateSingleTodoItem = in_memory.DAL.UpdateSingleTodoItem;
	                AbstractDeleteSingleTodo = in_memory.DAL.DeleteSingleTodo;
	            }
	            else if(dataaccesstype == 1)
	            {
	                AbstractValidatePathForList = sql.dal.DAL.ValidatePath;
	                AbstractValidatePathForListAndItem = sql.dal.DAL.ValidatePath;
	                //AbstractValidateUser = sql.dal.DAL.ValidateUser;
	
	                AbstractGetUsers = sql.dal.DAL.GetUsers;
	                AbstractGetTodoList = sql.dal.DAL.GetTodoList;
	                AbstractGetListsForUser = sql.dal.DAL.GetListsForUser;
	                AbstractCreateTodoList = sql.dal.DAL.CreateTodoList;
	                AbstractUpdateTodoList = sql.dal.DAL.UpdateTodoList;
	                AbstractDeleteTodoList = sql.dal.DAL.DeleteTodoList;
	                AbstractAddNewTodo = sql.dal.DAL.AddNewTodo;
	                AbstractGetSingleTodoItem = sql.dal.DAL.GetSingleTodoItem;
	                AbstractUpdateSingleTodoItem = sql.dal.DAL.UpdateSingleTodoItem;
	                AbstractDeleteSingleTodo = sql.dal.DAL.DeleteSingleTodo;
	            }

### Solution Structure
#### High-Level Projects
- webapi2.2.api: REST API. Includes PostMan 2.1 collection file for import.
- webapi22.example.dtos: friendly business-layer DTOs
- webapi22.example.validation: route and DTO validators, with DTO validators additionally providing extension methods. Route validators call into the abstract DAL. DTO validators are stand-alone.
- webapi22.example.data\_access: abstract DAL functions mentioned above.

#### Implementation Projects
- webapi22.example.data\_access.in\_memory: concrete in-memory provider
- webapi22.example.data\_access.sql: SQL provider - Schema creation script is located in the \LLBLGEN\schema\ folder.

### Compiled Self-Contained Folders
- compiled-osx - seems to work on OSX. Browse to the compiled os-x folder and run `dotnet webapi2.2.api.dll`
- compiled-win - VS publish used to work until yesterday. Now it builds perfectly but the publish fails when using Visual Studio. But it works from the CLI: `dotnet publish -o ..\compiled-win\ -c debug --self-contained true -r win-x64`. Simply run the webapi2.2.exe.

### Other
As this was based off the in-memory provider, I always found it easier to implement primary keys as GUIDs.

Also, if opening the solution in Visual Studio you might get prompted to install the PostSharp extension. Same for anything related to the concrete SQL implementation.

**start path should be /todos/logon**

#### Postman Bindings
Pre-configured Postman bindings are in the webapi2.2.api project in the Todo Lists.postman\_collection.json file for import into Postman.

**if getting ‘Could not get any response’, turn off SSL validation in PostMan**

[1]:	postsharp.net
[2]:	llblgen.com "LLBLGEN Pro"
[3]:	https://github.com/JeremySkinner/FluentValidation