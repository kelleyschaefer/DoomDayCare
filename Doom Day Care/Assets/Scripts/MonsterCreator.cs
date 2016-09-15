using UnityEngine;
using System.Collections;

public class MonsterCreator : MonoBehaviour
{
    private Vector3 menu_open;
    private Vector3 menu_close;

	// Use this for initialization
	void Start () {
        menu_close = new Vector3(1000, 1000, 0);
        menu_open = transform.localPosition;
        transform.localPosition = menu_close;
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            transform.localPosition = menu_close;
    }
	
    public void Open_Menu()
    {
        transform.localPosition = menu_open;
    }

    public void Close_Menu()
    {
        transform.localPosition = menu_close;
    }
}
