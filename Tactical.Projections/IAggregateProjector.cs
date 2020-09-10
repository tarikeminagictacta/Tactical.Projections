using Tactical.DDD;

namespace Tactical.Projections
{
    public interface IAggregateProjector<in T, TId>
        where TId : IEntityId
        where T : AggregateRoot<TId>
    {
        void ApplyProjections(T aggregate);
    }
}
