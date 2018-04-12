using System;
using System.Collections.Generic;

namespace Game
{
    enum Job
    {
        Hero = 0,
        Lancer,
        Mercenary,
        Pirate,

        NA,
    }

    class Fighter
    {
        public static IDictionary<Job, int> Movements = new Dictionary<Job, int>()
        {
            {Job.Hero, 5},
            {Job.Lancer, 4},
            {Job.Mercenary, 4},
            {Job.Pirate, 4},
        };

        public Job Job { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}
