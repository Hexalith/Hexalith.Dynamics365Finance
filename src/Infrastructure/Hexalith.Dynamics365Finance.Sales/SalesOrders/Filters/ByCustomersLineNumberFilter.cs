﻿// <copyright file="ByCustomersLineNumberFilter.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Dynamics365Finance.Sales.SalesOrders.Filters;

using System.Runtime.Serialization;

using Hexalith.Dynamics365Finance.Models;

[DataContract]
public record ByCustomersLineNumberFilter(string DataAreaId, [property: DataMember(Order = 2)] string SalesOrderNumber, [property: DataMember(Order = 3)] int CustomersLineNumber)
    : PerCompanyFilter(DataAreaId)
{
}