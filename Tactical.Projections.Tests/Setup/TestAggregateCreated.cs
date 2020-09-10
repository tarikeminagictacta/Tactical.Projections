using System;
using Tactical.DDD;

namespace Tactical.Projections.Tests.Setup
{
    public class TestAggregateCreated : IDomainEvent
    {
        public DateTime CreatedAt { get; set; }

        public TestAggregateCreated()
        {
            CreatedAt = DateTime.Now;
        }
    }
}