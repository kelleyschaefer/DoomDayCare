using UnityEngine;
using System.Collections.Generic;

public class TileMap : MonoBehaviour
{
    public GameObject player;

    public TileType[] tile_types;

    public int[,] tiles;

    public int map_size_x = 18;
    public int map_size_y = 10;

    private enum T
    {
        GRASS,
        CAULDRON
    };

    private void Start()
    {
        Generate_Map_Data();
        Generate_Map();
    }

    private void Generate_Map_Data()
    {
        tiles = new int[map_size_x, map_size_y];
        for(int i = 0; i < map_size_x; i++)
        {
            for(int j = 0; j < map_size_y; j++)
            {
                tiles[i, j] = (int)T.GRASS;
            }
        }
        tiles[5, 5] = (int)T.CAULDRON;
    }

    private void Generate_Map()
    {
        for (int i = 0; i < map_size_x; i++)
        {
            for (int j = 0; j < map_size_y; j++)
            {
                TileType tt = tile_types[tiles[i, j]];
                GameObject go = (GameObject)Instantiate(tt.tile_prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
}
