using UnityEngine;
using System.Collections;
using UnityEditor;

/*
 * For the time being, we can stick this script onto some object that starts the prototype.
 * When it begins, it'll instantiate the MonsterCompendium ScriptableObject
 * This object will exist in memory and regardless of scene (Meaning it won't be necessary to delete/load it between scenes)
 * 
 * Currently everything is just strings and hard-coded. In the future, Ingredients will be objects themselves
 * and Recipes will store Ingredient IDs
 * */

public class RecipeGeneration : MonoBehaviour {

	//Scriptable object holding Monster object type (Not GameObject type) and collection of them for identification
	//Monster object type holds the recipe necessary for creating the monster
	public MonsterCompendium MC;

	// Use this for initialization
	//TODO: Put this into Awake()
	void Start () {
		
		MC = (MonsterCompendium)ScriptableObject.CreateInstance (typeof(MonsterCompendium));
		MC.InstantiateCompendium ();

		foreach (Monster m in MC.Monsters){
			Debug.Log (m.Name);
		}

		foreach (Monster m in MC.Monsters) {
			string monster = "";
			monster += m.Name + ", Recipe: ";
			string[] temp = m.getRecipe ();
			monster+= temp [0] + ", ";
			monster+= temp [1] + ", ";
			monster+= temp [2] + ", ";
			monster+= temp [3];
			Debug.Log (monster);
		}

		string[] rep = { "Eyeball", "Tentacle", "Something", "Something" };
		Debug.Log(MC.fetchMonster (rep));

	}

	/*

	// Update is called once per frame
	void Update () {

	}

	*/
}
