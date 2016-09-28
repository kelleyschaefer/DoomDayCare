using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class PlayerMenu : MonoBehaviour
{
    public GameObject player;

    public GameObject ingredient_menu;
    public GameObject monster_menu;

    private Vector3 onscreen;
    private Vector3 offscreen = new Vector3(1000, 1000, 0);

	// Use this for initialization
	void Start () {
        onscreen = ingredient_menu.transform.localPosition;
        Hide_Ingredients();
        Hide_Monsters();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Show_Ingredients()
    {
        Update_Ingredients();
        ingredient_menu.transform.localPosition = onscreen;
    }

    public void Hide_Ingredients()
    {
        ingredient_menu.transform.localPosition = offscreen;
    }

    public void Show_Monsters()
    {
        Update_Monsters();
        monster_menu.transform.localPosition = onscreen;
    }

    public void Hide_Monsters()
    {
        monster_menu.transform.localPosition = offscreen;
    }

    private void Update_Monsters()
    {
        int child_count = GameObject.Find("Monster_Menu_Panel").transform.childCount;
        GameObject[] monster_panel = new GameObject[child_count];
        for (int i = 0; i < child_count; i++)
        {
            monster_panel[i] = GameObject.Find("Monster_Menu_Panel").transform.GetChild(i).gameObject;
        }

        List<Monster> monsters = player.GetComponent<Player>().monsters;

        for (int i = 0; i < child_count; i++)
        {
            if (i < monsters.Count)
            {
                monster_panel[i].SetActive(true);
                monster_panel[i].GetComponentInChildren<Image>().sprite = monsters[i].static_image;
                monster_panel[i].GetComponentInChildren<Text>().text = monsters[i].name;
            }
            else
            {
                monster_panel[i].SetActive(false);
            }
        }
    }

    private void Update_Ingredients()
    {
        int child_count = GameObject.Find("Ingredient_Menu_Panel").transform.childCount;
        GameObject[] ingredient_panel = new GameObject[child_count];
        for(int i = 0; i < child_count; i++)
        {
            ingredient_panel[i] = GameObject.Find("Ingredient_Menu_Panel").transform.GetChild(i).gameObject;
        }

        Dictionary<Ingredient, int> ing = player.GetComponent<Player>().ingredients;

        int count = 0;
        foreach(KeyValuePair<Ingredient, int> entry in ing)
        {
            ingredient_panel[count].SetActive(true);
            ingredient_panel[count].GetComponentInChildren<Image>().sprite = entry.Key.Ingredient_Image;
            ingredient_panel[count].GetComponentInChildren<Text>().text = entry.Key.Name + " X " + entry.Value;
            count++;
        }
        for(int i = count; i < ingredient_panel.Length; i++)
        {
            ingredient_panel[i].SetActive(false);
        }
    }
}
