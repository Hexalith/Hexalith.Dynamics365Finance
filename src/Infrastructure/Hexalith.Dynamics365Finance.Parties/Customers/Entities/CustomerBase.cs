﻿// ***********************************************************************
// Assembly         : Christofle.Infrastructure.Dynamics365Finance.RestClient
// Author           : Jérôme Piquot
// Created          : 01-13-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 02-08-2023
// ***********************************************************************
// <copyright file="CustomerBase.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Dynamics365Finance.Parties.Customers.Entities;

using System.Runtime.Serialization;

using Hexalith.Extensions.Common;
using Hexalith.Dynamics365Finance.Models;

/// <summary>
/// Class CustomerExternalCode.
/// Implements the <see cref="ODataElement" />
/// Implements the <see cref="IEquatable{ODataElement}" />
/// Implements the <see cref="IODataElement" />
/// Implements the <see cref="IEquatable{CustomerExternalCode}" />.
/// </summary>
/// <seealso cref="ODataElement" />
/// <seealso cref="IEquatable{ODataElement}" />
/// <seealso cref="IODataElement" />
/// <seealso cref="IEquatable{CustomerExternalCode}" />
[DataContract]
public record CustomerBase
(
    string DataAreaId,
    [property: DataMember(Order = 3)] string? CustomerAccount,
    string? Etag,
    [property: DataMember(Order = 4)] string? NameAlias,
    [property: DataMember(Order = 5)] string? PersonPersonalTitle = null,
    [property: DataMember(Order = 6)] int? PersonBirthDay = null,
    [property: DataMember(Order = 7)] Month? PersonBirthMonth = null,
    [property: DataMember(Order = 8)] int? PersonBirthYear = null)

: ODataElement(Etag, DataAreaId), IODataElement
{
    /// <summary>
    /// Entities the name.
    /// </summary>
    /// <returns>System.String.</returns>
    public static string EntityName() => "CustomersBase";
}