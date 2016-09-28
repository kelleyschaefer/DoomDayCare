using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour 
{

    public GameObject player;

    public TileType[] tile_types;

    public int[,] tiles;

    public int map_size_x = 10;
    public int map_size_y = 10;

    void Start()
    {
        GenerateMapData();
        GenerateMap();
    }

    private void GenerateMapData()
    {
        tiles = new int[map_size_x, map_size_y];
        for (int i = 0; i < map_size_x; i++)
        {
            for (int j = 0; j < map_size_y; j++)
            {
                tiles[i, j] = 0;
            }
        }

        for (int i = 3; i < 7; i++)
        {
            for (int j = 4; j < 8; j++)
            {
                tiles[i, j] = 1;
            }
        }
    }

    private void GenerateMap()
    {
        for (int i = 0; i < map_size_x; i++)
        {
            for (int j = 0; j < map_size_y; j++)
            {
                TileType tt = tile_types[tiles[i, j]];
                GameObject go = (GameObject)Instantiate(tt.tile_prefab, new Vector2(i, j), Quaternion.identity);
            }
        }

        for (int i = 0; i < map_size_x+2; i+=2)
        {
            for (int j = 0; j < map_size_y+1; j+=2)
            {
                if (i < 1 || i > map_size_x - 2)
                {
                    TileType tt = tile_types[2];
                    GameObject go = (GameObject)Instantiate(tt.tile_prefab, new Vector3(i, j, -3), Quaternion.identity);
                }
                else if (j < 1)
                {
                    TileType tt = tile_types[2];
                    GameObject go = (GameObject)Instantiate(tt.tile_prefab, new Vector3(i, j, -3), Quaternion.identity);
                }
                else if ( j > map_size_y - 2)
                {
                    TileType tt = tile_types[2];
                    GameObject go = (GameObject)Instantiate(tt.tile_prefab, new Vector3(i, j, -1), Quaternion.identity);
                }
            }
        }
    }
}
