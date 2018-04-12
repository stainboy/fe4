using System;

namespace Game
{
    static class Penalty
    {
        private static int[,] map;

        static Penalty()
        {
            var x = (int)Job.NA;
            var y = (int)TileClass.NA;
            map = (int[,])Array.CreateInstance(typeof(int), x, y);
            for (var i = 0; i < x; i++)
                for (var j = 0; j < y; j++)
                    map[i, j] = 1;

            Build(Job.Hero, TileClass.Forrest, 1);
            Build(Job.Hero, TileClass.River, 2);
            Build(Job.Hero, TileClass.Mountain, 2);

            Build(Job.Lancer, TileClass.Forrest, 2);
            Build(Job.Lancer, TileClass.River, int.MaxValue);
            Build(Job.Lancer, TileClass.Mountain, int.MaxValue);

            Build(Job.Mercenary, TileClass.Forrest, 2);
            Build(Job.Mercenary, TileClass.River, 3);
            Build(Job.Mercenary, TileClass.Mountain, 3);

            Build(Job.Pirate, TileClass.Forrest, 2);
            Build(Job.Pirate, TileClass.River, 1);
            Build(Job.Pirate, TileClass.Mountain, int.MaxValue);
        }

        private static void Build(Job job, TileClass tile, int penalty)
        {
            map[(int)job, (int)tile] = penalty;
        }

        public static int Get(Job job, TileClass tile)
        {
            return map[(int)job, (int)tile];
        }
    }
}
