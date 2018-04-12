using System;
using System.Collections.Generic;

namespace Game
{
    class Map
    {
        

        public Map(string path)
        {

        }

        public IList<Fighter> Allies { get; internal set; }
        public IList<Fighter> Enemies { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public Tile[,] Tiles { get; internal set; }

        internal void Print(object movements)
        {
            throw new NotImplementedException();
        }
    }
}
