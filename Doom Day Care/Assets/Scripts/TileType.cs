using UnityEngine;
using System.Collections;

[System.Serializable]
public class TileType
{
    public string name;
    public GameObject tile_prefab;

    public bool is_walkable = true;
}
