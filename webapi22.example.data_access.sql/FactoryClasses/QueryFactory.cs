﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.4.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using System.Linq;
using webapi22.example.data_access.sql.EntityClasses;
using webapi22.example.data_access.sql.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec.SelfServicingSpecific;
using SD.LLBLGen.Pro.QuerySpec;

namespace webapi22.example.data_access.sql.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory : QueryFactoryBase
	{
		/// <summary>Creates and returns a new EntityQuery for the TodoList entity</summary>
		public EntityQuery<TodoListEntity> TodoList { get { return Create<TodoListEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the TodoListItem entity</summary>
		public EntityQuery<TodoListItemEntity> TodoListItem { get { return Create<TodoListItemEntity>(); } }

		/// <summary>Creates and returns a new EntityQuery for the User entity</summary>
		public EntityQuery<UserEntity> User { get { return Create<UserEntity>(); } }

		/// <inheritdoc/>
		protected override IElementCreatorCore CreateElementCreator() { return new ElementCreator(); }
 
		/// <summary>Gets the query to fetch the typed list TodoListEntityDto</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of TodoListEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="webapi22.example.data_access.sql.TypedListClasses.TodoListEntityDtoRow"/> instances </returns>
		public DynamicQuery<webapi22.example.data_access.sql.TypedListClasses.TodoListEntityDtoRow> GetTodoListEntityDtoTypedList(EntityQuery<TodoListEntity> root=null)
		{
			var rootOfQuery = root ?? this.TodoList;
			return rootOfQuery
						.Select(() => new webapi22.example.data_access.sql.TypedListClasses.TodoListEntityDtoRow()
								{
									TodoListId = TodoListFields.TodoListId.ToValue<System.Guid>(),
									TodoListName = TodoListFields.TodoListName.ToValue<System.String>(),
									UserId = TodoListFields.UserId.ToValue<System.Guid>()
								});
		}

		/// <summary>Gets the query to fetch the typed list TodoListItemEntityDto</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of TodoListItemEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="webapi22.example.data_access.sql.TypedListClasses.TodoListItemEntityDtoRow"/> instances </returns>
		public DynamicQuery<webapi22.example.data_access.sql.TypedListClasses.TodoListItemEntityDtoRow> GetTodoListItemEntityDtoTypedList(EntityQuery<TodoListItemEntity> root=null)
		{
			var rootOfQuery = root ?? this.TodoListItem;
			return this.Create()
						.Select(() => new webapi22.example.data_access.sql.TypedListClasses.TodoListItemEntityDtoRow()
								{
									TodoListId = TodoListItemFields.TodoListId.ToValue<System.Guid>(),
									TodoListItemId = TodoListItemFields.TodoListItemId.ToValue<System.Guid>(),
									TodoListItemSubject = TodoListItemFields.TodoListItemSubject.ToValue<System.String>(),
									TodoListItemIsComplete = TodoListItemFields.TodoListItemIsComplete.ToValue<Nullable<System.Boolean>>(),
									UserId = TodoListFields.UserId.ToValue<System.Guid>()
								})
						.From(rootOfQuery
								.InnerJoin(this.TodoList).On(TodoListItemFields.TodoListId.Equal(TodoListFields.TodoListId)));
		}

		/// <summary>Gets the query to fetch the typed list UserEntityDto</summary>
		/// <param name="root">Optional. If specified (not null) it's used as the root of the query to fetch the typed list, otherwise a new EntityQuery(Of UserEntity) is used</param>
		/// <returns>Dynamic Query which fetches <see cref="webapi22.example.data_access.sql.TypedListClasses.UserEntityDtoRow"/> instances </returns>
		public DynamicQuery<webapi22.example.data_access.sql.TypedListClasses.UserEntityDtoRow> GetUserEntityDtoTypedList(EntityQuery<UserEntity> root=null)
		{
			var rootOfQuery = root ?? this.User;
			return rootOfQuery
						.Select(() => new webapi22.example.data_access.sql.TypedListClasses.UserEntityDtoRow()
								{
									UserId = UserFields.UserId.ToValue<System.Guid>(),
									UserName = UserFields.UserName.ToValue<System.String>()
								});
		}

	}
}