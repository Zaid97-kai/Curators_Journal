// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-03-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-22-2022
// ***********************************************************************
// <copyright file="UserConfiguration.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using CuratorMagazineWebAPI.Models.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuratorMagazineWebAPI.Models.EntityTypeConfigurations;

/// <summary>
/// Class UserConfiguration.
/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CuratorMagazineWebAPI.Models.Entities.User}" />
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CuratorMagazineWebAPI.Models.Entities.User}" />
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(x => x.Mother)
            .WithMany(x => x.MotherChildrens)
            .HasForeignKey(x => x.MotherId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);            
            
        builder
            .HasOne(x => x.Father)
            .WithMany(x => x.FatherChildrens)
            .HasForeignKey(x => x.FatherId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);            
            
        builder
            .HasOne(x => x.Division)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.DivisionId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);            
            
        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);            
            
        builder
            .HasOne(x => x.Group)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.GroupId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}