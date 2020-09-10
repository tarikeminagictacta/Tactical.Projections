using System.Collections.Generic;
using Tactical.DDD;

namespace Tactical.Projections
{
    public abstract class AggregateProjector<T, TId> : IAggregateProjector<T, TId>
        where T : AggregateRoot<TId>
        where TId : IEntityId
    {
        protected readonly IEnumerable<IAggregateProjection<T, TId>> Projections;

        protected AggregateProjector(IEnumerable<IAggregateProjection<T, TId>> projections)
        {
            Projections = projections;
        }

        public void ApplyProjections(T aggregate)
        {
            foreach (var aggregateProjection in Projections)
            {
                aggregateProjection.ProjectAggregate(aggregate);
            }
        }
    }
}
