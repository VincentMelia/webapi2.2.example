﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.4.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using webapi22.example.data_access.EntityClasses;
using webapi22.example.data_access.FactoryClasses;

namespace webapi22.example.data_access.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData : ILinqMetaData
	{
		/// <summary>CTor. Using this ctor will leave the transaction object to use empty. This is ok if you're not executing queries created with this
		/// meta data inside a transaction. If you're executing the queries created with this meta-data inside a transaction, either set the Transaction property
		/// on the IQueryable.Provider instance of the created LLBLGenProQuery object prior to execution or use the ctor which accepts a transaction object.</summary>
		public LinqMetaData() : this(null, null) { }
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse) : this(transactionToUse, null) { }
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse, FunctionMappingStore customFunctionMappings)
		{
			this.TransactionToUse = transactionToUse;
			this.CustomFunctionMappings = customFunctionMappings;
		}
		
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			switch((webapi22.example.data_access.EntityType)typeOfEntity)
			{
				case webapi22.example.data_access.EntityType.TodoListEntity:
					return this.TodoList;
				case webapi22.example.data_access.EntityType.TodoListItemEntity:
					return this.TodoListItem;
				case webapi22.example.data_access.EntityType.UserEntity:
					return this.User;
				default:
					return null;
			}		}

		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <typeparam name="TEntity">the type of the entity to get the datasource for</typeparam>
		/// <returns>the requested datasource</returns>
		public DataSource<TEntity> GetQueryableForEntity<TEntity>()
				where TEntity : class
		{
			return new DataSource<TEntity>(this.TransactionToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse);
		}

		/// <summary>returns the datasource to use in a Linq query when targeting TodoListEntity instances in the database.</summary>
		public DataSource<TodoListEntity> TodoList
		{
			get { return new DataSource<TodoListEntity>(this.TransactionToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting TodoListItemEntity instances in the database.</summary>
		public DataSource<TodoListItemEntity> TodoListItem
		{
			get { return new DataSource<TodoListItemEntity>(this.TransactionToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource<UserEntity> User
		{
			get { return new DataSource<UserEntity>(this.TransactionToUse, new ElementCreator(), this.CustomFunctionMappings, this.ContextToUse); }
		}


		/// <summary> Gets / sets the ITransaction to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public ITransaction TransactionToUse { get; set; }

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings { get; set; }
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse { get; set; }
	}
}