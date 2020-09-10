using Tactical.DDD;

namespace Tactical.Projections.Tests.Setup
{
    public sealed class TestAggregate : AggregateRoot<TestId>
    {
        public override TestId Id { get; protected set; }

        public TestAggregate(TestId id)
        {
            Id = id;
            AddDomainEvent(new TestAggregateCreated());
        }

        public void AddEvent1()
        {
            AddDomainEvent(new TestAggregateEvent1());
        }

        public void AddEvent2()
        {
            AddDomainEvent(new TestAggregateEvent2());
        }
    }
}
