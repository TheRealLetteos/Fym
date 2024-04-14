using System;

[Serializable]
public class TileInfo
{
    public int posX, posY, posZ;  
    public string tileType;        // Add an icon?


    public TileInfo(int x, int y, int z, string type)
    {
        posX = x;
        posY = y;
        posZ = z;
        tileType = type;
    }
}