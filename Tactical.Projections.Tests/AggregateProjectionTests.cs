using FluentAssertions;
using Tactical.Projections.Tests.Setup;
using Tactical.Projections.Tests.Setup.Projections;
using Xunit;

namespace Tactical.Projections.Tests
{
    public class AggregateProjectionTests
    {
        private readonly TestAggregate _aggregate;

        public AggregateProjectionTests()
        {
            var id = new TestId();
            var aggregate = new TestAggregate(id);
            aggregate.AddEvent1();
            aggregate.AddEvent2();
            _aggregate = aggregate;
        }

        [Fact]
        public void PartialProjectionShouldApplyCorrectEvents()
        {
            var sut = new PartialProjection();

            sut.ProjectAggregate(_aggregate);

            sut.IgnoredEvents.Should().Contain(nameof(TestAggregateCreated));
            sut.IgnoredEvents.Should().Contain(nameof(TestAggregateEvent2));
            sut.ProjectedEvents.Should().Contain(nameof(TestAggregateEvent1));
        }

        [Fact]
        public void IgnoringPartialProjectionShouldApplyCorrectEvents()
        {
            var sut = new IgnoringPartialProjection();

            sut.ProjectAggregate(_aggregate);

            sut.ProjectedEvents.Should().Contain(nameof(TestAggregateEvent2));
            sut.ProjectedEvents.Should().NotContain(nameof(TestAggregateEvent1));
            sut.ProjectedEvents.Should().NotContain(nameof(TestAggregateCreated));
            sut.IgnoredEvents.Should().NotContain(nameof(TestAggregateEvent1));
            sut.IgnoredEvents.Should().NotContain(nameof(TestAggregateCreated));
        }

        [Fact]
        public void FullProjectionShouldApplyCorrectEvents()
        {
            var sut = new FullProjection();

            sut.ProjectAggregate(_aggregate);

            sut.ProjectedEvents.Should().Contain(nameof(TestAggregateEvent2));
            sut.ProjectedEvents.Should().Contain(nameof(TestAggregateEvent1));
            sut.ProjectedEvents.Should().Contain(nameof(TestAggregateCreated));
        }
    }
}
