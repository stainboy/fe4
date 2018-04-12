using System;

namespace Game
{
    class PathFinding
    {
        private Map map;

        public PathFinding(Map map)
        {
            this.map = map;
        }

        internal IMovements CalculatePossibleMovements(Fighter f)
        {
            var m = Fighter.Movements[f.Job];
            var r = CreateDijkstraResult(map.X, map.Y);
            r[f.X, f.Y].Movements = m;
            Dijkstra(m, f.X, f.Y, Direction.NA, f.Job, map.Tiles, r);
            return new Movements(r);
        }

        private void Dijkstra(int m, int x, int y, Direction d, Job job, Tile[,] tiles, Result[,] r)
        {
            var p = Penalty.Get(job, tiles[x, y].Class);
            if (m - p >= r[x, y].Movements)
            {
                r[x, y].From = d;
                r[x, y].Movements = m - p;

                if (y > 0 && d != Direction.Down)
                    Dijkstra(m - p, x, y - 1, Direction.Up, job, tiles, r);
                if (y < r.GetLength(1) - 1 && d != Direction.Up)
                    Dijkstra(m - p, x, y + 1, Direction.Down, job, tiles, r);
                if (x > 0 && d != Direction.Right)
                    Dijkstra(m - p, x - 1, y, Direction.Left, job, tiles, r);
                if (x < r.GetLength(0) - 1 && d != Direction.Left)
                    Dijkstra(m - p, x + 1, y, Direction.Right, job, tiles, r);
            }
        }

        private Result[,] CreateDijkstraResult(int x, int y)
        {
            var r = new Result[x, y];
            for (var i = 0; i < x; i++)
                for (var j = 0; j < y; j++)
                    r[i, j].Movements = -1;
            return r;
        }

        internal IMovements CalculateShortestPath(Fighter src, Fighter dst)
        {
            throw new NotImplementedException();
        }

        private struct Result
        {
            public Direction From;
            public int Movements;
        }
        private enum Direction
        {
            NA,
            Up,
            Down,
            Left,
            Right,
        }
    }



    internal class Movements : IMovements
    {
        private object r;

        public Movements(object r)
        {
            this.r = r;
        }
    }

    interface IMovements
    {
    }
}
