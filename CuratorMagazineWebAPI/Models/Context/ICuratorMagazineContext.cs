// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-03-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-22-2022
// ***********************************************************************
// <copyright file="ICuratorMagazineContext.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using CuratorMagazineWebAPI.Models.Entities;
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CuratorMagazineWebAPI.Models.Context
{
    /// <summary>
    /// Interface ICuratorMagazineContext
    /// </summary>
    public interface ICuratorMagazineContext
    {
        #region Entities

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the divisions.
        /// </summary>
        /// <value>The divisions.</value>
        public DbSet<Division> Divisions { get; set; }
        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>The groups.</value>
        public DbSet<Group> Groups { get; set; }
        /// <summary>
        /// Gets or sets the parents.
        /// </summary>
        /// <value>The parents.</value>
        public DbSet<Parent> Parents { get; set; }
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public DbSet<Role> Roles { get; set; }

        #endregion
    }
}
