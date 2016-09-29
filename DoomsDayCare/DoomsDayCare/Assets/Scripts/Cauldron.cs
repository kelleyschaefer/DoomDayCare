using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{

    public GameObject player;
    public GameObject MonsterList;
	public GameObject IngredientList;
    public GameObject Monster_World_Prefab;
    public GameObject monster_dialog_box;


	public Ingredient[] currentIngredients = new Ingredient[3];
	private int lastIngredient;


	// Use this for initialization
	void Start () {
        monster_dialog_box.SetActive(false);
		lastIngredient = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setIngredient(int ingIndex){
		if (lastIngredient > 2) {
			lastIngredient = 0;
		}
		currentIngredients [lastIngredient] = IngredientList.GetComponent<IngredientList>().ingredients[ingIndex];
		lastIngredient++;
		showIngredients ();

	}

	public void showIngredients(){
		GameObject ing1 = GameObject.Find ("Ingredient1");
		GameObject ing2 = GameObject.Find ("Ingredient2");
		GameObject ing3 = GameObject.Find ("Ingredient3");

		if (!ing1.GetComponentInChildren<Image> ().IsActive()) {
			ing1.GetComponentInChildren<Image> ().sprite = currentIngredients [0].Ingredient_Image;
			ing1.GetComponentInChildren<Image> ().gameObject.SetActive (true);
		} else {
			ing1.GetComponentInChildren<Image> ().sprite = currentIngredients [0].Ingredient_Image;
		}
		if (!ing2.GetComponentInChildren<Image> ().IsActive()) {
			ing2.GetComponentInChildren<Image> ().sprite = currentIngredients [1].Ingredient_Image;
			ing1.GetComponentInChildren<Image> ().gameObject.SetActive (true);
		} else {
			ing2.GetComponentInChildren<Image> ().sprite = currentIngredients [1].Ingredient_Image;
		}
		if (!ing3.GetComponentInChildren<Image> ().IsActive()) {
			ing3.GetComponentInChildren<Image> ().sprite = currentIngredients [2].Ingredient_Image;
			ing1.GetComponentInChildren<Image> ().gameObject.SetActive (true);
		} else {
			ing3.GetComponentInChildren<Image> ().sprite = currentIngredients [2].Ingredient_Image;
		}
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
