using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "MonsterCompendium", menuName = "Monsters", order =1)]
public class MonsterCompendium: ScriptableObject {
	public Monster[] Monsters;

	public string[] sideIngredients = {"Bones","Poop","Stone","Dirt","Mystery Meat", "Newt's Eye",
		"Whisper Root", "Snickers Bar"};

	public void InstantiateCompendium(){
		
		Monsters = new Monster[3];
		Monster Chimera = new Monster ("Chimera", "Lizard Tail", "Lion Claw", sideIngredients[Random.Range(0,8)], sideIngredients[Random.Range(0,8)]);
		Monster Phoenix = new Monster ("Phoenix", "Feather", "Flint and Steel", sideIngredients[Random.Range(0,8)], sideIngredients[Random.Range(0,8)]);
		Monster Beholder = new Monster("Beholder", "Eyeball", "Tentacle", sideIngredients[Random.Range(0,8)], sideIngredients[Random.Range(0,8)]);

		Monsters [0] = Chimera;
		Monsters [1] = Phoenix;
		Monsters [2] = Beholder;
	}

	public string fetchMonster(string[] Recipe){
		foreach (Monster m in Monsters) {
			string[] temp = m.getRecipe ();
			foreach (string s in temp) {
				if (s == Recipe [0]) {
					return m.Name;
				} 
				else
					break;
			}
		}
		return "None";
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