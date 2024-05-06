﻿// ***********************************************************************
// Assembly         : Hexalith.Dynamics365Finance.Parties
// Author           : Jérôme Piquot
// Created          : 11-21-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 11-21-2023
// ***********************************************************************
// <copyright file="CustomerAccountKey.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Dynamics365Finance.Parties.Customers.Entities;

using System.Runtime.Serialization;

using Hexalith.Dynamics365Finance.Models;

/// <summary>
/// Class CustomerAccountKey.
/// Implements the <see cref="PerCompanyPrimaryKey" />
/// Implements the <see cref="IPerCompanyPrimaryKey" />
/// Implements the <see cref="IPrimaryKey" />
/// Implements the <see cref="System.IEquatable{Hexalith.Dynamics365Finance.Models.PerCompanyPrimaryKey}" />
/// Implements the <see cref="System.IEquatable{Hexalith.Dynamics365Finance.Parties.Customers.Entities.CustomerAccountKey}" />.
/// </summary>
/// <seealso cref="PerCompanyPrimaryKey" />
/// <seealso cref="IPerCompanyPrimaryKey" />
/// <seealso cref="IPrimaryKey" />
/// <seealso cref="System.IEquatable{Hexalith.Dynamics365Finance.Models.PerCompanyPrimaryKey}" />
/// <seealso cref="System.IEquatable{Hexalith.Dynamics365Finance.Parties.Customers.Entities.CustomerAccountKey}" />
[DataContract]
public record CustomerAccountKey(string DataAreaId, [property: DataMember(Order = 2)] string CustomerAccount)
    : PerCompanyPrimaryKey(DataAreaId)
{
}