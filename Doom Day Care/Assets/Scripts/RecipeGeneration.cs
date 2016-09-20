using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

/*
 * For the time being, we can stick this script onto some object that starts the prototype.
 * When it begins, it'll instantiate the MonsterCompendium ScriptableObject
 * This object will exist in memory and regardless of scene (Meaning it won't be necessary to delete/load it between scenes)
 * 
 * Currently everything is just strings and hard-coded. In the future, Ingredients will be objects themselves
 * and Recipes will store Ingredient IDs
 * */

public class RecipeGeneration : MonoBehaviour {

    public Dropdown dropdownA;
    public Dropdown dropdownP;
    public Dropdown dropdownM;

    private Sprite[] sprites;

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

        dropdownA.ClearOptions();
        dropdownP.ClearOptions();
        dropdownM.ClearOptions();

        foreach (string s in MC.Animal)
        {
            dropdownA.options.Add(new Dropdown.OptionData() { text = s });
        }
        foreach (string s in MC.Plant)
        {
            dropdownP.options.Add(new Dropdown.OptionData() { text = s });
        }
        foreach (string s in MC.Mineral)
        {
            dropdownM.options.Add(new Dropdown.OptionData() { text = s });
        }

        dropdownA.value = 1;
        dropdownM.value = 1;
        dropdownP.value = 1;

        sprites = Resources.LoadAll<Sprite>("sprites");

    }

    public void Combine()
    {
        string ing1 = dropdownA.options[dropdownA.value].text;
        string ing2 = dropdownP.options[dropdownP.value].text;
        string ing3 = dropdownM.options[dropdownM.value].text;
        string[] recipe = { ing1, ing2, ing3 };
        
        Monster m = MC.fetchMonster(recipe);

        if (m == null)
        {
            Debug.Log("None");
        }
        else
        {
            Image mImage = GameObject.Find("Monster/Image").GetComponent<Image>();
            Debug.Log(m.Name + " ***Not actually what this is, most likely");
            if(m.Name == "Chimera")
            {
                mImage.sprite = sprites[0];
            }
            else if(m.Name == "Beholder")
            {
                mImage.sprite = sprites[1];
            }
            else if (m.Name == "Phoenix")
            {
                mImage.sprite = sprites[2];
            }
        }

        
    }

	/*

	// Update is called once per frame
	void Update () {

	}

	*/
}
