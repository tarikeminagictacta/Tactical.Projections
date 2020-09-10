namespace Tactical.Projections.Tests.Setup.Projections
{
    public class IgnoringPartialProjection : BaseTestProjection
    {
        public void ApplyEvent(TestAggregate aggregate, TestAggregateEvent2 @event)
        {
            ProjectedEvents.Add(@event.GetType().Name);
        }
    }
}
