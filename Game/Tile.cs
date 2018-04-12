using System;

namespace Game
{
    enum TileClass
    {
        Ground = 0,
        Forrest = 1,
        River = 2,
        Mountain = 3,

        NA
    }
    class Tile
    {
        internal TileClass Class;
    }
}
