using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterInteraction : MonoBehaviour
{
    public string[] sayings;
    public GameObject dialog_box;
    public Ingredient drop;

    //private Vector3 onscreen;

    void Start()
    {
        //onscreen = dialog_box.transform.localPosition;
        //Close_Dialog();
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close_Dialog();
        }
    }

    public void Close_Dialog()
    {
        //dialog_box.transform.localPosition = new Vector3(1000, 1000, 0);
        dialog_box.SetActive(false);
    }

    public void Open_Dialog()
    {
        int i = Random.Range(0, sayings.Length);
        dialog_box.GetComponentInChildren<Text>().text = sayings[i];
        //dialog_box.transform.position = onscreen;
        dialog_box.SetActive(true);
    }
}
