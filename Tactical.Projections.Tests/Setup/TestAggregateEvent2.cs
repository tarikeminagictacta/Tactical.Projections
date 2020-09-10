using System;
using Tactical.DDD;

namespace Tactical.Projections.Tests.Setup
{
    public class TestAggregateEvent2 : IDomainEvent
    {
        public DateTime CreatedAt { get; set; }

        public TestAggregateEvent2()
        {
            CreatedAt = DateTime.Now;
        }
    }
}