using UnityEngine;
using System.Collections;
using System.Threading;

public class Player : MonoBehaviour
{
    public int x;
    public int y;

    public GameObject map;
    public GameObject monster_menu;

    private bool up = false;
    private bool down = false;
    private bool left = false;
    private bool right = false;

    private void OnGUI()
    {
        if (up)
        {
            if (y < map.GetComponent<TileMap>().map_size_y - 1 && map.GetComponent<TileMap>().tile_types[map.GetComponent<TileMap>().tiles[x, y + 1]].is_walkable)
                y++;
            up = false;
        }
        if (down)
        {
            if (y > 0 && map.GetComponent<TileMap>().tile_types[map.GetComponent<TileMap>().tiles[x, y - 1]].is_walkable)
                y--;
            down = false;
        }
        if (left)
        {
            if (x > 0 && map.GetComponent<TileMap>().tile_types[map.GetComponent<TileMap>().tiles[x - 1, y]].is_walkable)
                x--;
            left = false;
        }
        if (right)
        {
            if (x < map.GetComponent<TileMap>().map_size_x - 1 && map.GetComponent<TileMap>().tile_types[map.GetComponent<TileMap>().tiles[x + 1, y]].is_walkable)
                x++;
            right = false;
        }
    }
	
	void Update ()
    {
        Player_Movement();
        Player_Interact();

        if (this.transform.position.x != x || this.transform.position.y != y)
        {
            this.transform.position = new Vector3(x, y, 0);
        }
	}

    private void Player_Interact()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (x > 3 && x < 7 && y > 3 && y < 7)
            {
                // Open Mixing Menu
                Debug.Log("Open Cauldron!");
                monster_menu.GetComponent<MonsterCreator>().Open_Menu();
            }
        }
    }

    private void Player_Movement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            up = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            down = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
    }
}
