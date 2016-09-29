using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // Players ingredient inventory
    public Dictionary<Ingredient, int> ingredients;

    // Players monsters
    public List<Monster> monsters = new List<Monster>();

    // Player start menu
    public GameObject menu;
    public GameObject modal;

    private Vector3 offscreen = new Vector3(1000, 1000, 0);

	// Use this for initialization
	void Start ()
    {
        Close_Menu();
        Starting_Ingredients();
	}

    void Update()
    {
        Player_Interaction();
    }

    private void Starting_Ingredients()
    {
        ingredients = new Dictionary<Ingredient, int>();
        Ingredient[] ingredient_list = GameObject.Find("IngredientList").GetComponent<IngredientList>().ingredients;
        ingredients.Add(ingredient_list[0], 1);
        ingredients.Add(ingredient_list[4], 1);
        ingredients.Add(ingredient_list[5], 1);
        ingredients.Add(ingredient_list[1], 1);
        ingredients.Add(ingredient_list[2], 1);
        ingredients.Add(ingredient_list[6], 1);
    }

    public void Open_Menu()
    {
        menu.transform.localPosition = new Vector3(0, 0, 0);
        modal.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void Close_Menu()
    {
        menu.transform.localPosition = offscreen;
        modal.transform.localPosition = offscreen;
    }

    private void Player_Interaction()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Open_Menu();
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Close_Menu();
        }
    }
	
}
