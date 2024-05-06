﻿// ***********************************************************************
// Assembly         : Christofle.Infrastructure.Dynamics365Finance.RestClient
// Author           : Jérôme Piquot
// Created          : 03-09-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 03-09-2023
// ***********************************************************************
// <copyright file="SalesInvoiceFilter.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.Dynamics365Finance.Sales.SalesInvoices.Filters;

using System.Runtime.Serialization;

using Hexalith.Dynamics365Finance.Models;

/// <summary>
/// Class SalesOrderKey.
/// Implements the <see cref="PerCompanyPrimaryKey" />
/// Implements the <see cref="IPerCompanyPrimaryKey" />
/// Implements the <see cref="IPrimaryKey" />
/// Implements the <see cref="IEquatable{PerCompanyPrimaryKey}" />
/// Implements the <see cref="IEquatable{SalesOrderKey}" />.
/// </summary>
/// <seealso cref="PerCompanyPrimaryKey" />
/// <seealso cref="IPerCompanyPrimaryKey" />
/// <seealso cref="IPrimaryKey" />
/// <seealso cref="IEquatable{PerCompanyPrimaryKey}" />
/// <seealso cref="IEquatable{SalesOrderKey}" />
[DataContract]
public record SalesInvoiceFilter(
    string DataAreaId,
    [property: DataMember(Order = 2)] string InvoiceNumber)
    : PerCompanyFilter(DataAreaId)
{
}