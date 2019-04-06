﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.4.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webapi22.example.dtos.Persistence
{
	/// <summary>Static class for (extension) methods for fetching and projecting instances of webapi22.example.dtos.DtoClasses.User from / to the entity model.</summary>
	public static partial class UserPersistence
	{
		private static readonly System.Linq.Expressions.Expression<Func<webapi22.example.data_access.sql.EntityClasses.UserEntity, webapi22.example.dtos.DtoClasses.User>> _projectorExpression = CreateProjectionFunc();
		private static readonly Func<webapi22.example.data_access.sql.EntityClasses.UserEntity, webapi22.example.dtos.DtoClasses.User> _compiledProjector = CreateProjectionFunc().Compile();
	
		/// <summary>Empty static ctor for triggering initialization of static members in a thread-safe manner</summary>
		static UserPersistence() { }
	
		/// <summary>Extension method which produces a projection to webapi22.example.dtos.DtoClasses.User which instances are projected from the 
		/// results of the specified baseQuery, which returns webapi22.example.data_access.sql.EntityClasses.UserEntity instances, the root entity of the derived element returned by this query.</summary>
		/// <param name="baseQuery">The base query to project the derived element instances from.</param>
		/// <returns>IQueryable to retrieve webapi22.example.dtos.DtoClasses.User instances</returns>
		public static IQueryable<webapi22.example.dtos.DtoClasses.User> ProjectToUser(this IQueryable<webapi22.example.data_access.sql.EntityClasses.UserEntity> baseQuery)
		{
			return baseQuery.Select(_projectorExpression);
		}
		
		/// <summary>Extension method which produces a projection to webapi22.example.dtos.DtoClasses.User which instances are projected from the
		/// webapi22.example.data_access.sql.EntityClasses.UserEntity entity instance specified, the root entity of the derived element returned by this method.</summary>
		/// <param name="entity">The entity to project from.</param>
		/// <returns>webapi22.example.data_access.sql.EntityClasses.UserEntity instance created from the specified entity instance</returns>
		public static webapi22.example.dtos.DtoClasses.User ProjectToUser(this webapi22.example.data_access.sql.EntityClasses.UserEntity entity)
		{
			return _compiledProjector(entity);
		}
		
		private static System.Linq.Expressions.Expression<Func<webapi22.example.data_access.sql.EntityClasses.UserEntity, webapi22.example.dtos.DtoClasses.User>> CreateProjectionFunc()
		{
			return p__0 => new webapi22.example.dtos.DtoClasses.User()
			{
				UserId = p__0.UserId,
				UserName = p__0.UserName,
	// __LLBLGENPRO_USER_CODE_REGION_START ProjectionRegion_User 
	// __LLBLGENPRO_USER_CODE_REGION_END 
			};
		}
		/// <summary>Creates a primary key predicate to be used in a Where() clause in a Linq query which is executed on the database to fetch the original entity instance the specified <see cref="dto"/> object was projected from.</summary>
		/// <param name="dto">The dto object for which the primary key predicate has to be created for.</param>
		/// <returns>ready to use expression</returns>
		public static System.Linq.Expressions.Expression<Func<webapi22.example.data_access.sql.EntityClasses.UserEntity, bool>> CreatePkPredicate(webapi22.example.dtos.DtoClasses.User dto)
		{
			return p__0 => p__0.UserId == dto.UserId;
		}

		/// <summary>Creates a primary key predicate to be used in a Where() clause in a Linq query which is executed on the database to fetch the original entity instances the specified set of <see cref="dtos"/> objects was projected from.</summary>
		/// <param name="dtos">The dto objects for which the primary key predicate has to be created for.</param>
		/// <returns>ready to use expression</returns>
		public static System.Linq.Expressions.Expression<Func<webapi22.example.data_access.sql.EntityClasses.UserEntity, bool>> CreatePkPredicate(IEnumerable<webapi22.example.dtos.DtoClasses.User> dtos)
		{
			return p__0 => dtos.Select(p__1=>p__1.UserId).ToList().Contains(p__0.UserId);
		}

		/// <summary>Creates a primary key predicate to be used in a Where() clause in a Linq query on an IEnumerable in-memory set of entity instances to retrieve the original entity instance the specified <see cref="dto"/> object was projected from.</summary>
		/// <param name="dto">The dto object for which the primary key predicate has to be created for.</param>
		/// <returns>ready to use func</returns>
		public static Func<webapi22.example.data_access.sql.EntityClasses.UserEntity, bool> CreateInMemoryPkPredicate(webapi22.example.dtos.DtoClasses.User dto)
		{
			return p__0 => p__0.UserId == dto.UserId;
		}
		
		/// <summary>Updates the specified webapi22.example.data_access.sql.EntityClasses.UserEntity entity with the values stored in the dto object specified</summary>
		/// <param name="toUpdate">the entity instance to update.</param>
		/// <param name="dto">The dto object containing the source values.</param>
		/// <remarks>The PK field of toUpdate is set only if it's not marked as readonly.</remarks>
		public static void UpdateFromUser(this webapi22.example.data_access.sql.EntityClasses.UserEntity toUpdate, webapi22.example.dtos.DtoClasses.User dto)
		{
			if((toUpdate == null) || (dto == null))
			{
				return;
			}
			toUpdate.UserName = dto.UserName;
		}
	}
}

 