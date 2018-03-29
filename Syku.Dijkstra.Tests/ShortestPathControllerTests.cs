using FluentAssertions;
using Xunit;

namespace Syku.Dijkstra.Tests
{
    public class ShortestPathControllerTests
    {
        private ShortestPathController GetController()
        {
            var dijkstra = new DijkstraShortestPathService();
            return new ShortestPathController(dijkstra);
        }

        [Fact]
        public void ShortestDistanceIsCalculatedCorrectly()
        {
            var controller = GetController();

            var result = controller.GetDistance("A", "J");
            result.Should().Be(18);

            var result2 = controller.GetDistance("A", "D");
            result2.Should().Be(1);

            var result3 = controller.GetDistance("A", "F");
            result3.Should().Be(26);
        }
    }
}
