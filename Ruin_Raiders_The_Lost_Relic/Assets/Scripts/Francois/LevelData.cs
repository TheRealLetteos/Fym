using System.Collections.Generic;
using System;

[Serializable]
public class LevelData
{
    public List<TileInfo> tiles;

    public LevelData()
    {
        tiles = new List<TileInfo>(); // data struct for our level. 
    }
}