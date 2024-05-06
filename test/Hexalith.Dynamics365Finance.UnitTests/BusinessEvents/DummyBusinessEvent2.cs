// <copyright file="DummyBusinessEvent2.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Dynamics365Finance.UnitTests.BusinessEvents;

using System.Runtime.Serialization;

using Hexalith.Application.Commands;
using Hexalith.Dynamics365Finance.BusinessEvents;
using Hexalith.Extensions.Helpers;

[DataContract]
public class DummyBusinessEvent2 : Dynamics365BusinessEventBase
{
    public override string AggregateId => ValueTwo.ToInvariantString();

    public override string AggregateName => nameof(DummyBusinessEvent1);

    public int ValueTwo { get; set; }

    public override IEnumerable<BaseCommand> ToCommands() => throw new NotSupportedException();

    protected override int DefaultMajorVersion() => 10;

    protected override int DefaultMinorVersion() => 11;
}