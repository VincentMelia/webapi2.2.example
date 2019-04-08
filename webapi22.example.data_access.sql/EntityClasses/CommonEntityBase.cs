﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.4.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Collections.Generic;
using webapi22.example.data_access.sql;
using webapi22.example.data_access.sql.FactoryClasses;
using webapi22.example.data_access.sql.DaoClasses;
using webapi22.example.data_access.sql.RelationClasses;
using webapi22.example.data_access.sql.CollectionClasses;
using webapi22.example.data_access.sql.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Runtime.Serialization;

namespace webapi22.example.data_access.sql.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Common base class which is the base class for all generated entities which aren't a subtype of another entity.</summary>
	[Serializable]
	public abstract partial class CommonEntityBase : EntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END

		/// <summary>CTor</summary>
		protected CommonEntityBase() { }
		
		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CommonEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		/// <inheritdoc/>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider() { return ModelInfoProviderSingleton.GetInstance(); }
		
		/// <inheritdoc/>
		protected override ITransaction CreateTransaction( IsolationLevel levelOfIsolation, string name ) { return new Transaction(levelOfIsolation, name);	}

		/// <inheritdoc/>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider() { return new TypeDefaultValue(); }
		
		/// <inheritdoc/>
		protected override IEntityFactory GetEntityFactoryFromCache(int entityTypeEnumValue) { return EntityFactoryFactory.GetFactory((webapi22.example.data_access.sql.EntityType)entityTypeEnumValue); }

		/// <inheritdoc/>
		protected override Type LLBLGenProEntityTypeEnumType
		{
			get { return typeof(webapi22.example.data_access.sql.EntityType); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}
