using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Cauldron : MonoBehaviour
{

    public GameObject player;
    public GameObject MonsterList;
	public GameObject IngredientList;
    public GameObject Monster_World_Prefab;
    public GameObject monster_dialog_box;

    public GameObject ing1;
    public GameObject ing2;
    public GameObject ing3;

    public GameObject discovery_modal;

	public List<Ingredient> currentIngredients = new List<Ingredient>();
	private int lastIngredient;


	// Use this for initialization
	void Start () {
        monster_dialog_box.SetActive(false);
		lastIngredient = 0;

        Deactivate_Ingredients();
        discovery_modal.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setIngredient(int ingIndex)
    {
		if (lastIngredient > 2)
        {
			lastIngredient = 0;
		}
		currentIngredients [lastIngredient] = IngredientList.GetComponent<IngredientList>().ingredients[ingIndex];
		lastIngredient++;
        
		showIngredients ();

	}

	public void showIngredients()
    {
		if (!ing1.activeSelf) {
			ing1.GetComponent<Image>().sprite = currentIngredients [0].Ingredient_Image;
            ing1.SetActive(true);
		}
		else if (!ing2.activeSelf) {
			ing2.GetComponent<Image>().sprite = currentIngredients [1].Ingredient_Image;
			ing2.SetActive(true);
		}
		else if (!ing3.activeSelf) {
			ing3.GetComponent<Image>().sprite = currentIngredients [2].Ingredient_Image;
			ing3.SetActive(true);
		}
	}

    public void Combine()
    {
        Deactivate_Ingredients();
        foreach (Monster m in MonsterList.GetComponent<MonsterList>().monster_list)
        {
            bool found_monster = true;
            Debug.Log("Monster: " + m.name);
            foreach (Ingredient i in m.recipe)
            {
                bool contained = false;
                foreach(Ingredient j in currentIngredients)
                {
                    Debug.Log(i.Name + " " + j.Name + " " + (i.Name == j.Name));
                    if (i.Name == j.Name)
                        contained = true;
                }
                if (!contained)
                {
                    found_monster = false;
                    break;
                }
            }
            if(found_monster)
            {
                Debug.Log("worked");
                Add_Monster_To_World(m);
                Add_Monster_to_Player(m);
                discovery_modal.GetComponentInChildren<Text>().text = "Congratulations You Created a " + m.name;
                discovery_modal.SetActive(true);
                return;
            }
        }
        discovery_modal.GetComponentInChildren<Text>().text = "Sorry that was a bad recipe";
        discovery_modal.SetActive(true);
    }

    public void Deactivate_Ingredients()
    {
        ing1.SetActive(false);
        ing2.SetActive(false);
        ing3.SetActive(false);
    }

    private void Add_Monster_to_Player(Monster m)
    {
        player.GetComponent<Player>().monsters.Add(m);
    }

    private void Add_Monster_To_World(Monster m)
    {
        GameObject pf = Monster_World_Prefab;
        pf.GetComponent<Animator>().runtimeAnimatorController = m.controller;
        pf.GetComponent<MonsterInteraction>().sayings = m.sayings;
        pf.GetComponent<MonsterInteraction>().drop = m.drop;
        pf.GetComponent<MonsterInteraction>().dialog_box = monster_dialog_box;
        Vector3 location = new Vector3(Random.Range(-14, -6), Random.Range(-7, 3), 0);
        GameObject go = (GameObject)Instantiate(pf, location, Quaternion.identity);
    }
}
