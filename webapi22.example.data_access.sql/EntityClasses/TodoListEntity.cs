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
	/// <summary>Entity class which represents the entity 'TodoList'. <br/><br/></summary>
	[Serializable]
	public partial class TodoListEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection	_todoListItems;
		private UserEntity _user;
		private bool	_userReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static TodoListEntityStaticMetaData _staticMetaData = new TodoListEntityStaticMetaData();
		private static TodoListRelations _relationsFactory = new TodoListRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
			/// <summary>Member name TodoListItems</summary>
			public static readonly string TodoListItems = "TodoListItems";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class TodoListEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public TodoListEntityStaticMetaData()
			{
				SetEntityCoreInfo("TodoListEntity", InheritanceHierarchyType.None, false, (int)webapi22.example.data_access.sql.EntityType.TodoListEntity, typeof(TodoListEntity), typeof(TodoListEntityFactory), false);
				AddNavigatorMetaData<TodoListEntity, TodoListItemCollection>("TodoListItems", a => a._todoListItems, (a, b) => a._todoListItems = b, a => a.TodoListItems, () => new TodoListRelations().TodoListItemEntityUsingTodoListId, typeof(TodoListItemEntity), (int)webapi22.example.data_access.sql.EntityType.TodoListItemEntity);
				AddNavigatorMetaData<TodoListEntity, UserEntity>("User", "TodoLists", (a, b) => a._user = b, a => a._user, (a, b) => a.User = b, webapi22.example.data_access.sql.RelationClasses.StaticTodoListRelations.UserEntityUsingUserIdStatic, ()=>new TodoListRelations().UserEntityUsingUserId, null, new int[] { (int)TodoListFieldIndex.UserId }, null, true, (int)webapi22.example.data_access.sql.EntityType.UserEntity);
			}
		}
		
		/// <summary>Static ctor</summary>
		static TodoListEntity()
		{
		}

		/// <summary>CTor</summary>
		public TodoListEntity() :base()
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		public TodoListEntity(System.Guid todoListId)
		{
			InitClassFetch(todoListId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public TodoListEntity(System.Guid todoListId, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(todoListId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="validator">The custom validator object for this TodoListEntity</param>
		public TodoListEntity(System.Guid todoListId, IValidator validator)
		{
			InitClassFetch(todoListId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TodoListEntity(SerializationInfo info, StreamingContext context):base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}



		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid todoListId)
		{
			return FetchUsingPK(todoListId, null, null, null);
		}

		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid todoListId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(todoListId, prefetchPathToUse, null, null);
		}

		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid todoListId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(todoListId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary>Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Guid todoListId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(todoListId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <inheritdoc/>
		public override bool Refetch()
		{
			return Fetch(this.TodoListId, null, null, null);
		}

		/// <summary>Retrieves all related entities of type 'TodoListItemEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'TodoListItemEntity'</returns>
		public webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection GetMultiTodoListItems(bool forceFetch)
		{
			return GetMultiTodoListItems(forceFetch, _todoListItems.EntityFactoryToUse, null);
		}

		/// <summary>Retrieves all related entities of type 'TodoListItemEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'TodoListItemEntity'</returns>
		public webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection GetMultiTodoListItems(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiTodoListItems(forceFetch, _todoListItems.EntityFactoryToUse, filter);
		}

		/// <summary>Retrieves all related entities of type 'TodoListItemEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection GetMultiTodoListItems(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiTodoListItems(forceFetch, entityFactoryToUse, null);
		}

		/// <summary>Retrieves all related entities of type 'TodoListItemEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection GetMultiTodoListItems(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
			return PerformMultiEntityLazyLoading<webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection>("TodoListItems", forceFetch, entityFactoryToUse, (c,r)=>c.GetMultiManyToOne(this, filter));
		}

		/// <summary>Sets the collection parameters for the collection for 'TodoListItems'. These settings will be taken into account
		/// when the property TodoListItems is requested or GetMultiTodoListItems is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersTodoListItems(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_todoListItems.SortClauses=sortClauses;
			_todoListItems.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary>Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleUser(bool forceFetch=false)
		{
			return PerformSingleEntityLazyLoading<UserEntity>("User", forceFetch, _userReturnsNewIfNotFound, e=>e.FetchUsingPK(this.UserId));
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
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="validator">The validator object for this TodoListEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Guid todoListId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(todoListId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			_todoListItems = new webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection();
			_todoListItems.SetContainingEntityInfo(this, "TodoList");
			_userReturnsNewIfNotFound = false;
			PerformDependencyInjection();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}


		/// <summary>Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="todoListId">PK value for TodoList which data should be fetched into this TodoList object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Guid todoListId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)TodoListFieldIndex.TodoListId].ForcedCurrentValueWrite(todoListId);
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
		protected override IDao CreateDAOInstance() { return DAOFactory.CreateTodoListDAO(); }
		
		/// <summary>Gets the entity static meta data instance from the generated type.</summary>
		/// <returns>The instance requested</returns>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() { return _staticMetaData; }
		
		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static TodoListRelations Relations { get { return _relationsFactory; } }


		/// <summary>Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'TodoListItem' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTodoListItems { get { return _staticMetaData.GetPrefetchPathElement("TodoListItems", new webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection()); } }

		/// <summary>Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUser { get { return _staticMetaData.GetPrefetchPathElement("User", new webapi22.example.data_access.sql.CollectionClasses.UserCollection()); } }


		/// <summary>The TodoListId property of the Entity TodoList<br/><br/></summary>
		/// <remarks>Mapped on  table field: "TodoList"."TodoListId"<br/>
		/// Table field type characteristics (type, precision, scale, length): UniqueIdentifier, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Guid TodoListId
		{
			get { return (System.Guid)GetValue((int)TodoListFieldIndex.TodoListId, true); }
			set	{ SetValue((int)TodoListFieldIndex.TodoListId, value, true); }
		}

		/// <summary>The UserId property of the Entity TodoList<br/><br/></summary>
		/// <remarks>Mapped on  table field: "TodoList"."UserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): UniqueIdentifier, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Guid UserId
		{
			get { return (System.Guid)GetValue((int)TodoListFieldIndex.UserId, true); }
			set	{ SetValue((int)TodoListFieldIndex.UserId, value, true); }
		}

		/// <summary>The TodoListName property of the Entity TodoList<br/><br/></summary>
		/// <remarks>Mapped on  table field: "TodoList"."TodoListName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String TodoListName
		{
			get { return (System.String)GetValue((int)TodoListFieldIndex.TodoListName, true); }
			set	{ SetValue((int)TodoListFieldIndex.TodoListName, value, true); }
		}

		/// <summary>Retrieves all related entities of type 'TodoListItemEntity' using a relation of type '1:n'.<br/><br/></summary>
		public virtual webapi22.example.data_access.sql.CollectionClasses.TodoListItemCollection TodoListItems { get { return GetMultiTodoListItems(false); } }

		/// <summary>Gets / sets the lazy loading flag for TodoListItems. When set to true, TodoListItems is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time TodoListItems is accessed. You can always execute/ a forced fetch by calling GetMultiTodoListItems(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchTodoListItems
		{
			get	{ return GetAlwaysFetchValueForNavigator("TodoListItems"); }
			set	{ SetAlwaysFetchValueForNavigator("TodoListItems", value); }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property TodoListItems already has been fetched. Setting this property to false when TodoListItems has been fetched
		/// will clear the TodoListItems collection well. Setting this property to true while TodoListItems hasn't been fetched disables lazy loading for TodoListItems</summary>
		[Browsable(false)]
		public bool AlreadyFetchedTodoListItems
		{
			get { return GetAlreadyFetchedValueForNavigator("TodoListItems");}
			set { SetAlreadyFetchedValueForNavigator("TodoListItems", value, true);}
		}

		/// <summary>Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/></summary>
		[Browsable(false)]
		public virtual UserEntity User
		{
			get	{ return GetSingleUser(false); }
			set { SetSingleRelatedEntityNavigator(value, "User"); }
		}

		/// <summary>Gets / sets the lazy loading flag for User. When set to true, User is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time User is accessed. You can always execute a forced fetch by calling GetSingleUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUser
		{
			get	{ return GetAlwaysFetchValueForNavigator("User"); }
			set	{ SetAlwaysFetchValueForNavigator("User", value); }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property User already has been fetched. Setting this property to false when User has been fetched
		/// will set User to null as well. Setting this property to true while User hasn't been fetched disables lazy loading for User</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUser
		{
			get { return GetAlreadyFetchedValueForNavigator("User");}
			set { SetAlreadyFetchedValueForNavigator("User", value, true);}
		}

		/// <summary>Gets / sets the flag for what to do if the related entity available through the property User is not found
		/// in the database. When set to true, User will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool UserReturnsNewIfNotFound
		{
			get	{ return _userReturnsNewIfNotFound; }
			set { _userReturnsNewIfNotFound = value; }	
		}



		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace webapi22.example.data_access.sql
{
	public enum TodoListFieldIndex
	{
		///<summary>TodoListId. </summary>
		TodoListId,
		///<summary>UserId. </summary>
		UserId,
		///<summary>TodoListName. </summary>
		TodoListName,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace webapi22.example.data_access.sql.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: TodoList. </summary>
	public partial class TodoListRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between TodoListEntity and TodoListItemEntity over the 1:n relation they have, using the relation between the fields: TodoList.TodoListId - TodoListItem.TodoListId</summary>
		public virtual IEntityRelation TodoListItemEntityUsingTodoListId
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "TodoListItems", true, new[] { TodoListFields.TodoListId, TodoListItemFields.TodoListId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between TodoListEntity and UserEntity over the m:1 relation they have, using the relation between the fields: TodoList.UserId - User.UserId</summary>
		public virtual IEntityRelation UserEntityUsingUserId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "User", false, new[] { UserFields.UserId, TodoListFields.UserId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticTodoListRelations
	{
		internal static readonly IEntityRelation TodoListItemEntityUsingTodoListIdStatic = new TodoListRelations().TodoListItemEntityUsingTodoListId;
		internal static readonly IEntityRelation UserEntityUsingUserIdStatic = new TodoListRelations().UserEntityUsingUserId;

		/// <summary>CTor</summary>
		static StaticTodoListRelations() { }
	}
}
