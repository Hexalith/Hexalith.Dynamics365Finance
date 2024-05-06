﻿// ***********************************************************************
// Assembly         : Hexalith.UnitTests
// Author           : Jérôme Piquot
// Created          : 12-06-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 12-06-2023
// ***********************************************************************
// <copyright file="CustomerConverterTest.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Dynamics365Finance.UnitTests.Parties.Customers.Helpers;

using FluentAssertions;

using Hexalith.Domain.Events;
using Hexalith.Domain.ValueObjets;
using Hexalith.Dynamics365Finance.Parties.Customers.Entities;
using Hexalith.Dynamics365Finance.Parties.Customers.Helpers;

using Xunit;

/// <summary>
/// Class CustomerConverterTest.
/// </summary>
public class CustomerConverterTest
{
    /// <summary>
    /// Defines the test method CustomerInformationChangedCheckAggregateId.
    /// </summary>
    [Fact]
    public void CustomerInformationChangedCheckAggregateId()
    {
        Contact contact = DummyContact();
        CustomerInformationChanged e = new(
            "PART1",
            "Company1",
            "ORIG1",
            "Cust123456",
            contact.Person.Name,
            PartyType.Person,
            contact,
            "WH2",
            "COM5",
            "GRP2",
            "EUR",
            new DateTimeOffset(2003, 10, 25, 11, 16, 35, TimeSpan.FromHours(3)));

        CustomerV3 customer = e.ToDynamics365FinanceCustomer(e.Id);

        CustomerInformationChanged newEvent = customer.ToCustomerChangedEvent(
            e.PartitionId,
            e.CompanyId,
            e.OriginId,
            e.Id,
            e.Date,
            e.Contact.PostalAddress.PostBox,
            e.Contact.PostalAddress.StateName,
            e.Contact.PostalAddress.CountryName,
            e.Contact.Phone,
            e.Contact.Mobile,
            "Mr",
            contact.Person.BirthDate);
        _ = newEvent.Should().BeEquivalentTo(e);
    }

    private static Contact DummyContact()
            => new(
            DummyPerson(),
            DummyPostalAddress(),
            "jdoe@mymail.com",
            "+33321563",
            "+33652952");

    private static Person DummyPerson()
                     => new(
             "John Doe",
             "John",
             "Doe",
             "Mr",
             new DateTimeOffset(2001, 12, 25, 0, 0, 0, TimeSpan.Zero),
             Gender.Female);

    private static PostalAddress DummyPostalAddress()
        => new(
            "Primary address",
            "Primary address",
            "31",
            "Coventry street",
            "25669",
            "67008",
            "London",
            "LD",
            "LDN",
            "London City",
            "GBR",
            "Great Britain",
            "GB",
            null,
            null,
            null,
            null);
}