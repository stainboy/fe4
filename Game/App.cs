using System;

namespace Game
{
    class App
    {
        static void Main(string[] args)
        {
            var map = new Map("map1.yml");
            var algo = new PathFinding(map);

            // show allie's possible movements
            foreach (var f in map.Allies)
            {
                var movements = algo.CalculatePossibleMovements(f);
                map.Print(movements);
            }

            // show ememy's path finding against weakest allie
            var w = map.Allies[2];
            foreach (var e in map.Enemies)
            {
                var movements = algo.CalculateShortestPath(e, w);
                map.Print(movements);
            }
        }
    }
}
