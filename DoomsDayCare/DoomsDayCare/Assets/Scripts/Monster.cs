using UnityEngine;
using System.Collections;

[System.Serializable]
public class Monster
{
    public string name;
    public Ingredient[] recipe;
    public Sprite static_image;
    public Ingredient drop;
    public string[] sayings;
    public UnityEngine.RuntimeAnimatorController controller;
}
