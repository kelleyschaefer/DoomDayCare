using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "MonsterCompendium", menuName = "Monsters", order =1)]
public class MonsterCompendium: ScriptableObject {
	public Monster[] Monsters;

	public string[] sideIngredients = {"Bones","Poop","Stone","Dirt","Mystery Meat", "Newt's Eye",
		"Whisper Root", "Snickers Bar"};

    public string[] Animal = {"Bones", "Newt's Eye", "Mystery Meat", "Eyeball", "Lizard Tail", "Lion Claw", "Feather", "Tentacle" };
    public string[] Plant = {"Whisper Root", "Grass", "Poison Ivy", "Grave Mushroom", "Ivy" };
    public string[] Mineral = {"Dirt", "Stone", "Flint", "Iron", "Crystal" };
    public string[] Special = {"Fresh Soul", "Candy Bar", "Elemental Fire" };

	public void InstantiateCompendium(){
		
		Monsters = new Monster[3];
		Monster Chimera = new Monster ("Chimera", "Lizard Tail", "Lion Claw", Animal[Random.Range(0,Animal.Length)], Mineral[Random.Range(0,Mineral.Length)]);
		Monster Phoenix = new Monster ("Phoenix", "Feather", "Flint and Steel", Plant[Random.Range(0,Plant.Length)], Mineral[Random.Range(0,Mineral.Length)]);
		Monster Beholder = new Monster("Beholder", "Eyeball", "Tentacle", Animal[Random.Range(0,Animal.Length)], Plant[Random.Range(0,Plant.Length)]);

		Monsters [0] = Chimera;
		Monsters [1] = Phoenix;
		Monsters [2] = Beholder;
	}

	public Monster fetchMonster(string[] Recipe){
		foreach (Monster m in Monsters) {
			string[] temp = m.getRecipe ();
			foreach (string s in temp) {
				if (s == Recipe [0]) {
                    return m;
				} 
				else
					break;
			}
		}
		return null;
	}
}

/*
 * Contains array that is the Recipe for the monster and the monster's name.
 * In actual implementation this will hold all [base] information about a Monster in addition to Name and Recipe. 
 * (Ie. Potential colors, personality, needs, price, whatever)
 * */
public class Monster{
	
	public string Name;
	private string[] Recipe;
			
	public Monster(string name, string ing1, string ing2, string ing3, string ing4){
		Recipe = new string[4];
		Name = name;
		Recipe [0] = ing1;
		Recipe [1] = ing2;
		Recipe [2] = ing3;
		Recipe [3] = ing4;
	}		
					
	public string[] getRecipe(){
		return Recipe;
	}

	public void setRecipe(string[] newRecipe){
		Recipe = newRecipe;
	}

}

public class Ingredient{

    public string Name;
    public string Category;
    public int ID;

    public Ingredient(string name, string category, int id){
        Name = name;
        Category = category;
        ID = id;
    }


}