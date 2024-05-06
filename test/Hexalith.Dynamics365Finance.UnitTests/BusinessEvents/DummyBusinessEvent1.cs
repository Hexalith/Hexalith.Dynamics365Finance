﻿// <copyright file="DummyBusinessEvent1.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Dynamics365Finance.UnitTests.BusinessEvents;

using System.Runtime.Serialization;

using Hexalith.Application.Commands;
using Hexalith.Dynamics365Finance.BusinessEvents;

[DataContract]
public class DummyBusinessEvent1 : Dynamics365BusinessEventBase
{
    public override string AggregateId => ValueOne;

    public override string AggregateName => nameof(DummyBusinessEvent1);

    public string ValueOne { get; set; }

    public override IEnumerable<BaseCommand> ToCommands() => throw new NotSupportedException();

    protected override int DefaultMajorVersion() => 6;

    protected override int DefaultMinorVersion() => 7;
}