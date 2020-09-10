using Tactical.DDD;

namespace Tactical.Projections.Tests.Setup.Projections
{
    public class PartialProjection : BaseTestProjection
    {
        public void ApplyEvent(TestAggregate aggregate, TestAggregateEvent1 @event)
        {
            ProjectedEvents.Add(@event.GetType().Name);
        }

        protected override void ApplyEvent(TestAggregate aggregate, IDomainEvent @event)
        {
            IgnoredEvents.Add(@event.GetType().Name);
        }
    }
}
