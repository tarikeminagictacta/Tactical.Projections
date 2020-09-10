using System.Collections.Generic;

namespace Tactical.Projections.Tests.Setup.Projections
{
    public class BaseTestProjection : AggregateProjection<TestAggregate, TestId>
    {
        public List<string> ProjectedEvents = new List<string>();
        public List<string> IgnoredEvents = new List<string>();
    }
}
