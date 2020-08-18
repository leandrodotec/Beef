﻿using Beef.Demo.Business.DataSvc;
using Beef.Events;
using System;
using System.Threading.Tasks;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Business
{
    public partial class RobotManager
    {
        private readonly IEventPublisher _evtPub;

        public RobotManager(IRobotDataSvc dataService, IEventPublisher evtPub) : this(dataService) => _evtPub = Check.NotNull(evtPub, nameof(evtPub));

        private async Task RaisePowerSourceChangeOnImplementationAsync(Guid id, RefDataNamespace.PowerSource powerSource)
        {
            var e = new EventData<string>
            {
                Subject = $"Demo.Robot.{id}",
                Action = "PowerSourceChange",
                Value = powerSource,
                Key = id
            };

            await _evtPub.PublishAsync(e).ConfigureAwait(false);
        }
    }
}