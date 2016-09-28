using UnityEngine;
using System.Collections;

[System.Serializable]
public class Monster
{
    public string name;
    public Ingredient[] recipe;
    public Sprite static_image;
    public GameObject visual_prefab;
    public Ingredient drop;
}
