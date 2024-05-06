﻿// <copyright file="DummyEntity.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Dynamics365Finance.UnitTests.Client;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Dynamics365Finance.Models;

[DataContract]
public record DummyEntity : ODataElement, IODataElement
{
    [JsonConstructor]
    public DummyEntity(string etag, string dataAreaId, string message)
        : base(etag, dataAreaId)
    {
        ArgumentException.ThrowIfNullOrEmpty(message);
        Message = message;
    }

    [DataMember]
    [JsonPropertyName("message")]
    public string Message { get; }

    public static string EntityName() => "Dummy";
}