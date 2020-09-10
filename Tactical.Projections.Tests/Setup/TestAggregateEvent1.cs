using System;
using Tactical.DDD;

namespace Tactical.Projections.Tests.Setup
{
    public class TestAggregateEvent1 : IDomainEvent
    {
        public DateTime CreatedAt { get; set; }

        public TestAggregateEvent1()
        {
            CreatedAt = DateTime.Now;
        }
    }
}