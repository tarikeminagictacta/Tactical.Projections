namespace Tactical.Projections.Tests.Setup.Projections
{
    public class FullProjection : BaseTestProjection
    {
        public void ApplyEvent(TestAggregate aggregate, TestAggregateCreated @event)
        {
            ProjectedEvents.Add(@event.GetType().Name);
        }

        public void ApplyEvent(TestAggregate aggregate, TestAggregateEvent1 @event)
        {
            ProjectedEvents.Add(@event.GetType().Name);
        }

        public void ApplyEvent(TestAggregate aggregate, TestAggregateEvent2 @event)
        {
            ProjectedEvents.Add(@event.GetType().Name);
        }
    }
}
