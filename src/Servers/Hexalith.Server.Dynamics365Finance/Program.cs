// <copyright file="Program.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

using Hexalith.Application.Events;
using Hexalith.Application.Organizations.Helpers;
using Hexalith.Dynamics365Finance.Inventories.PartnerInventoryItems.Helpers;
using Hexalith.Dynamics365Finance.Parties.Customers.IntegrationEvents;
using Hexalith.Dynamics365Finance.Parties.Helpers;
using Hexalith.ExternalSystems.EventsWebApis.Helpers;
using Hexalith.Infrastructure.DaprRuntime.ExternalSystems.Helpers;
using Hexalith.Infrastructure.DaprRuntime.Helpers;
using Hexalith.Infrastructure.WebApis.Helpers;
using Hexalith.Inventories.Domain.InventoryItems;
using Hexalith.Inventories.Domain.PartnerInventoryItems;
using Hexalith.Inventories.EventsWebApis.Helpers;
using Hexalith.Parties.DaprRuntime.Helpers;
using Hexalith.Parties.Domain.Helpers;
using Hexalith.Parties.Events;
using Hexalith.Parties.EventsWebApis.Helpers;
using Hexalith.Server.Dynamics365Finance;

IEnumerable<string> aggregateNames = [PartiesDomainHelper.CustomerAggregateName];
WebApplicationBuilder builder = HexalithWebApi.CreateApplication(
    Dynamics365FinanceConstants.ApplicationName,
    "v1",
    (actors) =>
    {
        _ = actors.AddExternalSystemsMapper(Dynamics365FinanceConstants.ApplicationId, aggregateNames);
        _ = actors.AddPartiesProjections(Dynamics365FinanceConstants.ApplicationId);
        actors.RegisterProjectionActor<PartnerInventoryItem>(Dynamics365FinanceConstants.ApplicationId);
        actors.RegisterProjectionActor<InventoryItem>(Dynamics365FinanceConstants.ApplicationId);
    },
    args);

builder.Services
    .AddCustomerProjections(Dynamics365FinanceConstants.ApplicationId)
    .AddInventoryItemsProjections(Dynamics365FinanceConstants.ApplicationId)
    .AddPartnerInventoryItemsProjections(Dynamics365FinanceConstants.ApplicationId)
    .AddExternalSystemsMapperSubscription(Dynamics365FinanceConstants.ApplicationId, aggregateNames)
    .AddDynamics365FinanceCustomers(builder.Configuration, Dynamics365FinanceConstants.ApplicationId)
    .AddDynamics365FinancePartnerInventoryItems(builder.Configuration)
    .AddOrganizations(builder.Configuration)
    .AddScoped<IIntegrationEventHandler<CustomerRegistered>, CustomerRegisteredHandler>()
    .AddScoped<IIntegrationEventHandler<CustomerInformationChanged>, CustomerInformationChangedHandler>()
    .AddScoped<IIntegrationEventProcessor, IntegrationEventProcessor>()
    .AddScoped<IIntegrationEventDispatcher, DependencyInjectionEventDispatcher>();

await builder
    .Build()
    .UseHexalith<Program>(Dynamics365FinanceConstants.ApplicationName)
    .RunAsync()
    .ConfigureAwait(false);