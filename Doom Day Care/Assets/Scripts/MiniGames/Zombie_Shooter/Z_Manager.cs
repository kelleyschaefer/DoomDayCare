using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Z_Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile_prefab;
    public GameObject zombie_prefab;
    public List<GameObject> zombies;
    private List<GameObject> projectiles;

    public GameObject game_end;
    private Vector3 game_end_open;
    private Vector3 game_end_close;

    private int number_zombies = 5;
    private int kills = 0;
     
	void Start ()
    {
        game_end_open = game_end.transform.localPosition;
        game_end_close = new Vector3(1000, 1000, 0);
        game_end.transform.localPosition = game_end_close;
        zombies = new List<GameObject>();
        projectiles = new List<GameObject>();
        Spawn_Zombies();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Fire()
    {
        GameObject shot = (GameObject)Instantiate(projectile_prefab, player.transform.position, Quaternion.identity);
        shot.GetComponent<Z_Projectile>().manager = gameObject;
        projectiles.Add(shot);
    }

    public void Remove_Zombie(GameObject zombie)
    {
        zombies.Remove(zombie);
        Destroy(zombie);
        GameObject.Find("Score").GetComponent<Text>().text = (number_zombies - zombies.Count).ToString();

        if (zombies.Count == 0)
        {
            // Player wins
            Game_Over(true);
        }
    }

    public void Game_Over(bool win)
    {
        if(win)
        {
            game_end.GetComponentsInChildren<Text>()[0].text = "YOU WIN!";
            game_end.transform.localPosition = game_end_open;
        }
        else
        {
            game_end.GetComponentsInChildren<Text>()[0].text = "YOU LOSE =(";
            game_end.transform.localPosition = game_end_open;
        }
    }

    private void Spawn_Zombies()
    {
        for(int i = 0; i < number_zombies; i++)
        {
            GameObject zombie = (GameObject)Instantiate(zombie_prefab, new Vector3(Random.Range(0, 17), 9, 0), Quaternion.identity);
            zombie.GetComponent<Z_Enemy>().player = player;
            zombies.Add(zombie);
        }
    }

    public void Return_To_World()
    {
        Application.LoadLevel(0);
    }
}
