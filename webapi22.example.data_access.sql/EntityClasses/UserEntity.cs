﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.4.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using webapi22.example.data_access.sql.FactoryClasses;
using webapi22.example.data_access.sql.DaoClasses;
using webapi22.example.data_access.sql.RelationClasses;
using webapi22.example.data_access.sql.HelperClasses;
using webapi22.example.data_access.sql.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace webapi22.example.data_access.sql.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'User'. <br/><br/></summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private webapi22.example.data_access.sql.CollectionClasses.TodoListCollection	_todoLists;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static UserEntityStaticMetaData _staticMetaData = new UserEntityStaticMetaData();
		private static UserRelations _relationsFactory = new UserRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name TodoLists</summary>
			public static readonly string TodoLists = "TodoLists";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class UserEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public UserEntityStaticMetaData()
			{
				SetEntityCoreInfo("UserEntity", InheritanceHierarchyType.None, false, (int)webapi22.example.data_access.sql.EntityType.UserEntity, typeof(UserEntity), typeof(UserEntityFactory), false);
				AddNavigatorMetaData<UserEntity, TodoListCollection>("TodoLists", a => a._todoLists, (a, b) => a._todoLists = b, a => a.TodoLists, () => new UserRelations().TodoListEntityUsingUserId, typeof(TodoListEntity), (int)webapi22.example.data_access.sql.EntityType.TodoListEntity);
			}
		}
		
		/// <summary>Static ctor</summary>
		static UserEntity()
		{
		}

		/// <summary>CTor</summary>
		public UserEntity() :base()
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		public UserEntity(System.Guid userId)
		{
			InitClassFetch(userId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public UserEntity(System.Guid userId, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(userId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(System.Guid userId, IValidator validator)
		{
			InitClassFetch(userId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected UserEntity(SerializationInfo info, StreamingContext context):base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}



		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid userId)
		{
			return FetchUsingPK(userId, null, null, null);
		}

		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid userId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(userId, prefetchPathToUse, null, null);
		}

		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid userId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(userId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid userId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(userId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <inheritdoc/>
		public override bool Refetch()
		{
			return Fetch(this.UserId, null, null, null);
		}

		/// <summary>Retrieves all related entities of type 'TodoListEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'TodoListEntity'</returns>
		public webapi22.example.data_access.sql.CollectionClasses.TodoListCollection GetMultiTodoLists(bool forceFetch)
		{
			return GetMultiTodoLists(forceFetch, _todoLists.EntityFactoryToUse, null);
		}

		/// <summary>Retrieves all related entities of type 'TodoListEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'TodoListEntity'</returns>
		public webapi22.example.data_access.sql.CollectionClasses.TodoListCollection GetMultiTodoLists(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiTodoLists(forceFetch, _todoLists.EntityFactoryToUse, filter);
		}

		/// <summary>Retrieves all related entities of type 'TodoListEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public webapi22.example.data_access.sql.CollectionClasses.TodoListCollection GetMultiTodoLists(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiTodoLists(forceFetch, entityFactoryToUse, null);
		}

		/// <summary>Retrieves all related entities of type 'TodoListEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual webapi22.example.data_access.sql.CollectionClasses.TodoListCollection GetMultiTodoLists(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
			return PerformMultiEntityLazyLoading<webapi22.example.data_access.sql.CollectionClasses.TodoListCollection>("TodoLists", forceFetch, entityFactoryToUse, (c,r)=>c.GetMultiManyToOne(this, filter));
		}

		/// <summary>Sets the collection parameters for the collection for 'TodoLists'. These settings will be taken into account
		/// when the property TodoLists is requested or GetMultiTodoLists is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersTodoLists(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_todoLists.SortClauses=sortClauses;
			_todoLists.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		private void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			this.Fields = CreateFields();
			this.Validator = validatorToUse;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}		

		/// <summary>Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The validator object for this UserEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Guid userId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(userId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			_todoLists = new webapi22.example.data_access.sql.CollectionClasses.TodoListCollection();
			_todoLists.SetContainingEntityInfo(this, "User");
			PerformDependencyInjection();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}


		/// <summary>Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Guid userId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)UserFieldIndex.UserId].ForcedCurrentValueWrite(userId);
				CreateDAOInstance().FetchExisting(this, this.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (this.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}

		/// <summary>Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance() { return DAOFactory.CreateUserDAO(); }
		
		/// <summary>Gets the entity static meta data instance from the generated type.</summary>
		/// <returns>The instance requested</returns>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() { return _staticMetaData; }
		
		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static UserRelations Relations { get { return _relationsFactory; } }


		/// <summary>Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'TodoList' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTodoLists { get { return _staticMetaData.GetPrefetchPathElement("TodoLists", new webapi22.example.data_access.sql.CollectionClasses.TodoListCollection()); } }


		/// <summary>The UserId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): UniqueIdentifier, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Guid UserId
		{
			get { return (System.Guid)GetValue((int)UserFieldIndex.UserId, true); }
			set	{ SetValue((int)UserFieldIndex.UserId, value, true); }
		}

		/// <summary>The UserName property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UserName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.UserName, true); }
			set	{ SetValue((int)UserFieldIndex.UserName, value, true); }
		}

		/// <summary>Retrieves all related entities of type 'TodoListEntity' using a relation of type '1:n'.<br/><br/></summary>
		public virtual webapi22.example.data_access.sql.CollectionClasses.TodoListCollection TodoLists { get { return GetMultiTodoLists(false); } }

		/// <summary>Gets / sets the lazy loading flag for TodoLists. When set to true, TodoLists is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time TodoLists is accessed. You can always execute/ a forced fetch by calling GetMultiTodoLists(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchTodoLists
		{
			get	{ return GetAlwaysFetchValueForNavigator("TodoLists"); }
			set	{ SetAlwaysFetchValueForNavigator("TodoLists", value); }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property TodoLists already has been fetched. Setting this property to false when TodoLists has been fetched
		/// will clear the TodoLists collection well. Setting this property to true while TodoLists hasn't been fetched disables lazy loading for TodoLists</summary>
		[Browsable(false)]
		public bool AlreadyFetchedTodoLists
		{
			get { return GetAlreadyFetchedValueForNavigator("TodoLists");}
			set { SetAlreadyFetchedValueForNavigator("TodoLists", value, true);}
		}



		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace webapi22.example.data_access.sql
{
	public enum UserFieldIndex
	{
		///<summary>UserId. </summary>
		UserId,
		///<summary>UserName. </summary>
		UserName,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace webapi22.example.data_access.sql.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: User. </summary>
	public partial class UserRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between UserEntity and TodoListEntity over the 1:n relation they have, using the relation between the fields: User.UserId - TodoList.UserId</summary>
		public virtual IEntityRelation TodoListEntityUsingUserId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "TodoLists", true, new[] { UserFields.UserId, TodoListFields.UserId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticUserRelations
	{
		internal static readonly IEntityRelation TodoListEntityUsingUserIdStatic = new UserRelations().TodoListEntityUsingUserId;

		/// <summary>CTor</summary>
		static StaticUserRelations() { }
	}
}
