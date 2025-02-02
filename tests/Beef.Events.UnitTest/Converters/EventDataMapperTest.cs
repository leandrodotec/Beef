﻿using Beef.Entities;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Beef.Events.UnitTest.Converters
{
    [TestFixture]
    public partial class AzureEventHubsEventConverterTest
    {
        [Test]
        public async Task SubjectOnly()
        {
            var ed = EventData.CreateEvent("Subject");
            var eh = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertToAsync(ed);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectAttributeName]);
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.ActionAttributeName));
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.TenantIdAttributeName));
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.KeyPropertyName));

            ed = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertFromAsync(eh);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual(null, ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(null, ed.Key);
        }

        [Test]
        public async Task SubjectAndAction()
        {
            var ed = EventData.CreateEvent("Subject", "Action");
            var eh = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertToAsync(ed);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectAttributeName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionAttributeName]);
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.TenantIdAttributeName));
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.KeyPropertyName));

            ed = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertFromAsync(eh);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(null, ed.Key);
        }

        [Test]
        public async Task SubjectActionAndKey()
        {
            var id = Guid.NewGuid();

            var ed = EventData.CreateEvent("Subject", "Action", id);
            Assert.IsNotNull(ed.EventId);
            var eid = ed.EventId;
            var eh = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertToAsync(ed);
            Assert.IsNotNull(eh);
            Assert.AreEqual(eid, eh.Properties[EventMetadata.EventIdAttributeName]);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectAttributeName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionAttributeName]);
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.TenantIdAttributeName));
            Assert.AreEqual(id, eh.Properties[EventMetadata.KeyPropertyName]);

            ed = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertFromAsync(eh);
            Assert.IsNotNull(eh);
            Assert.AreEqual(eid, ed.EventId);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(id, ed.Key);
        }

        [Test]
        public async Task SubjectActionAndArrayKey()
        {
            var id = Guid.NewGuid();
            var no = 123;

            var ed = EventData.CreateEvent("Subject", "Action", id, no);
            var eh = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertToAsync(ed);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectAttributeName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionAttributeName]);
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.TenantIdAttributeName));
            Assert.AreEqual(id, ((object[])eh.Properties[EventMetadata.KeyPropertyName])[0]);
            Assert.AreEqual(no, ((object[])eh.Properties[EventMetadata.KeyPropertyName])[1]);

            ed = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertFromAsync(eh);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(id, ((object[])ed.Key)[0]);
            Assert.AreEqual(no, ((object[])ed.Key)[1]);
        }

        public class Person : IGuidIdentifier
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        [Test]
        public async Task SubjectActionKeyAndValue()
        {
            var p = new Person { Id = Guid.NewGuid(), Name = "Caleb" };

            var ed = EventData.CreateValueEvent(p, "Subject", "Action");
            var eh = await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertToAsync(ed);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectAttributeName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionAttributeName]);
            Assert.IsFalse(eh.Properties.ContainsKey(EventMetadata.TenantIdAttributeName));
            Assert.AreEqual(p.Id, eh.Properties[EventMetadata.KeyPropertyName]);

            ed = (EventData<Person>) await new EventHubs.EventHubsEventConverter { UseMessagingPropertiesForMetadata = true }.ConvertFromAsync(typeof(Person), eh);
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(p.Id, ed.Key);
            Assert.IsNotNull(ed.Value);
            Assert.AreEqual(p.Id, ed.Value.Id);
            Assert.AreEqual(p.Name, ed.Value.Name);
        }
    }
}