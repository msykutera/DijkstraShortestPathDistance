using Microsoft.AspNetCore.Mvc;

namespace Syku.Dijkstra
{
    [Route("api/[controller]")]
    public class ShortestPathController : Controller
    {
        private readonly IShortestPath _shortestPath;

        public ShortestPathController(IShortestPath shortestPath)
        {
            _shortestPath = shortestPath;
        }

        [HttpGet("distance/{from}/{to}")]
        public double GetDistance(string from, string to)
        {
            var distance = _shortestPath.GetDistance(from, to);
            return distance;
        }
    }
}