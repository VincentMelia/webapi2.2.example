﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.4.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using webapi22.example.data_access.sql.FactoryClasses;
using webapi22.example.data_access.sql.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace webapi22.example.data_access.sql.HelperClasses
{
	/// <summary>Singleton implementation of the ModelInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	public static class ModelInfoProviderSingleton
	{
		private static readonly IModelInfoProvider _providerInstance = new ModelInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static ModelInfoProviderSingleton()	{ }

		/// <summary>Gets the singleton instance of the ModelInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IModelInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the ModelInfoProvider.</summary>
	internal class ModelInfoProviderCore : ModelInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="ModelInfoProviderCore"/> class.</summary>
		internal ModelInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass();
			InitTodoListEntityInfo();
			InitTodoListItemEntityInfo();
			InitUserEntityInfo();
			this.BuildInternalStructures();
		}

		/// <summary>Inits TodoListEntity's info objects</summary>
		private void InitTodoListEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(TodoListFieldIndex), "TodoListEntity");
			this.AddElementFieldInfo("TodoListEntity", "TodoListId", typeof(System.Guid), true, false, false, false,  (int)TodoListFieldIndex.TodoListId, 0, 0, 0);
			this.AddElementFieldInfo("TodoListEntity", "UserId", typeof(System.Guid), false, true, false, false,  (int)TodoListFieldIndex.UserId, 0, 0, 0);
			this.AddElementFieldInfo("TodoListEntity", "TodoListName", typeof(System.String), false, false, false, false,  (int)TodoListFieldIndex.TodoListName, 20, 0, 0);
		}

		/// <summary>Inits TodoListItemEntity's info objects</summary>
		private void InitTodoListItemEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(TodoListItemFieldIndex), "TodoListItemEntity");
			this.AddElementFieldInfo("TodoListItemEntity", "TodoListItemId", typeof(System.Guid), true, false, false, false,  (int)TodoListItemFieldIndex.TodoListItemId, 0, 0, 0);
			this.AddElementFieldInfo("TodoListItemEntity", "TodoListId", typeof(System.Guid), false, true, false, false,  (int)TodoListItemFieldIndex.TodoListId, 0, 0, 0);
			this.AddElementFieldInfo("TodoListItemEntity", "TodoListItemSubject", typeof(System.String), false, false, false, false,  (int)TodoListItemFieldIndex.TodoListItemSubject, 50, 0, 0);
			this.AddElementFieldInfo("TodoListItemEntity", "TodoListItemIsComplete", typeof(Nullable<System.Boolean>), false, false, false, true,  (int)TodoListItemFieldIndex.TodoListItemIsComplete, 0, 0, 0);
		}

		/// <summary>Inits UserEntity's info objects</summary>
		private void InitUserEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserFieldIndex), "UserEntity");
			this.AddElementFieldInfo("UserEntity", "UserId", typeof(System.Guid), true, false, false, false,  (int)UserFieldIndex.UserId, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "UserName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.UserName, 10, 0, 0);
		}

		/// <inheritdoc/>
		protected override IEntityFieldCore[] GetEntityFieldCoreArray(string entityName) { return this.GetEntityFieldCoreArray(entityName, PersistenceInfoProviderSingleton.GetInstance()); }
	}
}