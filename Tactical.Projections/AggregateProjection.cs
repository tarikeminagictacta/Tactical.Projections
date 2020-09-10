using Tactical.DDD;

namespace Tactical.Projections
{
    public abstract class AggregateProjection<T, TId> : IAggregateProjection<T, TId>
        where T : AggregateRoot<TId>
        where TId : IEntityId
    {
        public void ProjectAggregate(T aggregate)
        {
            foreach (var aggregateDomainEvent in aggregate.DomainEvents)
            {
                ((dynamic)this).ApplyEvent(aggregate, (dynamic)aggregateDomainEvent);
            }
        }

        /// <summary>
        /// Default projection, will fall back to this one if there is no implemented.
        /// Added here so that you do not need to implement every event, only those that
        /// interest this projection.
        /// </summary>
        /// <param name="aggregate">Final aggregate state</param>
        /// <param name="event">Projected domain event</param>
        protected virtual void ApplyEvent(T aggregate, IDomainEvent @event)
        {
            // ignore 
        }
    }
}