using Tactical.DDD;

namespace Tactical.Projections
{
    public interface IAggregateProjection<in T, TId>
        where TId : IEntityId
        where T : AggregateRoot<TId>
    {
        void ProjectAggregate(T aggregate);
    }
}
