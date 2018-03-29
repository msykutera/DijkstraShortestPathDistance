using FluentAssertions;
using System;
using Xunit;

namespace Syku.Dijkstra.Tests
{
    public class ShortestPathControllerTests : IDisposable
    {
        private readonly ShortestPathController _controller;

        public ShortestPathControllerTests()
        {
            var dijkstra = new DijkstraShortestPathService();
            _controller = new ShortestPathController(dijkstra);
        }

        [Fact]
        public void ShortestDistanceIsCalculatedCorrectly()
        {
            var result = _controller.GetDistance("A", "J");
            result.Should().Be(18);

            var result2 = _controller.GetDistance("A", "D");
            result2.Should().Be(1);

            var result3 = _controller.GetDistance("A", "F");
            result3.Should().Be(26);
        }

        public void Dispose()
        {
            _controller.Dispose();
        }
    }
}
