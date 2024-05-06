﻿// <copyright file="Dynamics365FinanceAndOperationsClientMockTest.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Dynamics365Finance.UnitTests.Client;

using FluentAssertions;

using Hexalith.Dynamics365Finance.Client;
using Hexalith.Dynamics365Finance.Configurations;
using Hexalith.Dynamics365Finance.TestMocks;

using Moq;
using Moq.Contrib.HttpClient;

using Xunit;

public class Dynamics365FinanceClientMockTest
{
    [Fact]
    public void BuildClientWithMockedResponseShouldSucceed()
    {
        Mock<HttpMessageHandler> mockHandler = new(MockBehavior.Strict);
        using HttpClient client = mockHandler.CreateClient();
        Dynamics365FinanceClientBuilder<DummyEntity> builder = new Dynamics365FinanceClientBuilder<DummyEntity>()
            .WithSettingsValue(
                new Dynamics365FinanceClientSettings { Instance = new Uri("https://test.dynamics.com") },
                new Application.Organizations.Configurations.OrganizationSettings { DefaultCompanyId = "CIE" });
        _ = builder
            .Invoking(y => y.Build(client))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void ClientWithApplicationJsonSettingsShouldSucceed()
    {
        Mock<HttpMessageHandler> mockHandler = new(MockBehavior.Strict);
        using HttpClient client = mockHandler.CreateClient();
        Dynamics365FinanceClientBuilder<DummyEntity> builder = new Dynamics365FinanceClientBuilder<DummyEntity>()
            .WithValueFromConfiguration<Dynamics365FinanceClientMockTest>();
        IDynamics365FinanceClient<DummyEntity> result = builder.Build(client);
        _ = result.Should().NotBeNull();
    }
}