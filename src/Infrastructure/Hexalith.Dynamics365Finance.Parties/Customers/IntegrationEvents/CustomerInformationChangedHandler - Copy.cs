// ***********************************************************************
// Assembly         : Hexalith.Dynamics365Finance.Parties
// Author           : Jérôme Piquot
// Created          : 11-18-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 12-13-2023
// ***********************************************************************
// <copyright file="CustomerSnapshotEventHandler.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.Dynamics365Finance.Parties.Customers.IntegrationEvents;

using System.Text.Json;

using Hexalith.Application.Commands;
using Hexalith.Application.Events;
using Hexalith.Domain.Events;
using Hexalith.Dynamics365Finance.Parties.Configuration;
using Hexalith.Dynamics365Finance.Parties.Customers.Services;
using Hexalith.Parties.Domain.Aggregates;
using Hexalith.Parties.Domain.Helpers;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

/// <summary>
/// Class CustomerSnapshotEventHandler.
/// Implements the <see cref="CustomerEventsHandler{CustomerInformationChanged}" />.
/// </summary>
/// <seealso cref="CustomerEventsHandler{CustomerInformationChanged}" />
public partial class CustomerSnapshotEventHandler : IntegrationEventHandlerBase<SnapshotEvent>
{
    /// <summary>
    /// The customer service.
    /// </summary>
    private readonly IDynamics365FinanceCustomerService _customerService;

    /// <summary>
    /// The logger.
    /// </summary>
#pragma warning disable IDE0052 // Remove unread private members
    private readonly ILogger<CustomerSnapshotEventHandler> _logger;
#pragma warning restore IDE0052 // Remove unread private members

    private readonly IOptions<Dynamics365FinancePartiesSettings> _partiesSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerSnapshotEventHandler"/> class.
    /// </summary>
    /// <param name="customerService">The customer service.</param>
    /// <param name="partiesSettings">The parties settings.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="System.ArgumentNullException">null.</exception>
    public CustomerSnapshotEventHandler(
        IDynamics365FinanceCustomerService customerService,
        IOptions<Dynamics365FinancePartiesSettings> partiesSettings,
        ILogger<CustomerSnapshotEventHandler> logger)
    {
        ArgumentNullException.ThrowIfNull(customerService);
        ArgumentNullException.ThrowIfNull(partiesSettings);
        ArgumentNullException.ThrowIfNull(logger);
        _customerService = customerService;
        _partiesSettings = partiesSettings;
        _logger = logger;
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseCommand>> ApplyAsync(SnapshotEvent baseEvent, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(baseEvent);
        if (baseEvent.SourceAggregateName != PartiesDomainHelper.CustomerAggregateName || baseEvent.SourceAggregateId == null || string.IsNullOrWhiteSpace(baseEvent.Snapshot))
        {
            // Ignore snapshot events from other aggregates
            return [];
        }

        if (_partiesSettings.Value.Customers?.SendCustomersToErpEnabled == true)
        {
            Customer? customer = JsonSerializer.Deserialize<Customer>(baseEvent.Snapshot);
            if (customer == null)
            {
                // Ignore snapshot events with invalid data
                return [];
            }

            _ = await _customerService
                .CreateCustomerAsync(customer.ToCustomerRegistered(), cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            LogSendCustomersToErpIsDisabledInformation();
        }

        return [];
    }

    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Send customers to Dynamics 365 Finance is disabled.")]
    private partial void LogSendCustomersToErpIsDisabledInformation();
}