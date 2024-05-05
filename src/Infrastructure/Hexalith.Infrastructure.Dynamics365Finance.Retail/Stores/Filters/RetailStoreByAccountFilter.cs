﻿// ***********************************************************************
// Assembly         : Hexalith.Infrastructure.Dynamics365Finance.Retail
// Author           : Jérôme Piquot
// Created          : 12-13-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 12-13-2023
// ***********************************************************************
// <copyright file="RetailStoreByAccountFilter.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Infrastructure.Dynamics365Finance.Retail.Stores.Filters;

using System.Runtime.Serialization;

using Hexalith.Infrastructure.Dynamics365Finance.Models;

/// <summary>
/// Class RetailStoreByAccountFilter.
/// Implements the <see cref="IFilter" />
/// Implements the <see cref="System.IEquatable{Hexalith.Infrastructure.Dynamics365Finance.Retail.Stores.Filters.RetailStoreByAccountFilter}" />.
/// </summary>
/// <seealso cref="IFilter" />
/// <seealso cref="System.IEquatable{Hexalith.Infrastructure.Dynamics365Finance.Retail.Stores.Filters.RetailStoreByAccountFilter}" />
[DataContract]
public record RetailStoreByAccountFilter
(
    [property: DataMember(Order = 1)] string RetailStoreAccount)
    : IFilter
{
}