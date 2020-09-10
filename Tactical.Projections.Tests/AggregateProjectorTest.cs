using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Tactical.Projections.Tests.Setup;
using Tactical.Projections.Tests.Setup.Projections;
using Tactical.Projections.Tests.Setup.Projectors;
using Xunit;

namespace Tactical.Projections.Tests
{
    public class AggregateProjectorTest
    {
        private readonly List<BaseTestProjection> _projections;
        private readonly TestAggregate _aggregate;

        public AggregateProjectorTest()
        {
            var id = new TestId();
            var aggregate = new TestAggregate(id);
            aggregate.AddEvent1();
            aggregate.AddEvent2();
            _aggregate = aggregate;
            _projections = new List<BaseTestProjection>
            {
                new PartialProjection(),
                new IgnoringPartialProjection(),
                new FullProjection()
            };
        }

        [Fact]
        public void TestProjectorShouldApplyEventsCorrectly()
        {
            var projector = new TestAggregateProjector(_projections);

            projector.ApplyProjections(_aggregate);

            projector.IgnoredEvents.Count(x => x == nameof(TestAggregateCreated)).Should().Be(1);
            projector.IgnoredEvents.Count(x => x == nameof(TestAggregateEvent1)).Should().Be(0);
            projector.IgnoredEvents.Count(x => x == nameof(TestAggregateEvent2)).Should().Be(1);
            projector.ProjectedEvents.Count(x => x == nameof(TestAggregateCreated)).Should().Be(1);
            projector.ProjectedEvents.Count(x => x == nameof(TestAggregateEvent1)).Should().Be(2);
            projector.ProjectedEvents.Count(x => x == nameof(TestAggregateEvent2)).Should().Be(2);
        }
    }
}
