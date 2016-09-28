using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // Players ingredient inventory
    public Dictionary<string, int> ingredients;

    // Players monsters
    public ArrayList monsters;

    // Player start menu
    public GameObject menu;

	// Use this for initialization
	void Start ()
    {
        Starting_Ingredients();
        monsters = new ArrayList();
	}

    private void Starting_Ingredients()
    {
        ingredients = new Dictionary<string, int>();
        ingredients.Add("ash", 1);
        ingredients.Add("stick", 1);
        ingredients.Add("feather", 1);
    }


	
}
