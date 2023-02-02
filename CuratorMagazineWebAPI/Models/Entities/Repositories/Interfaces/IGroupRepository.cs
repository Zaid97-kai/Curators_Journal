// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 12-19-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-22-2022
// ***********************************************************************
// <copyright file="IGroupRepository.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using CuratorMagazineWebAPI.Models.Entities.Domains;

namespace CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

/// <summary>
/// Interface IGroupRepository
/// Extends the <see cref="T:CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces.IGenericRepository`1" />
/// </summary>
public interface IGroupRepository : IBaseRepository<Group>
{
    
}