using System.Collections.Generic;
using System.Linq;
using Tactical.Projections.Tests.Setup.Projections;

namespace Tactical.Projections.Tests.Setup.Projectors
{
    public class TestAggregateProjector : AggregateProjector<TestAggregate, TestId>
    {
        private readonly IEnumerable<BaseTestProjection> _projections;

        public IReadOnlyCollection<string> ProjectedEvents => _projections.SelectMany(p => p.ProjectedEvents).ToList();
        public IReadOnlyCollection<string> IgnoredEvents => _projections.SelectMany(p => p.IgnoredEvents).ToList();

        public TestAggregateProjector(IReadOnlyCollection<BaseTestProjection> projections) : base(projections)
        {
            _projections = projections;
        }
    }
}
