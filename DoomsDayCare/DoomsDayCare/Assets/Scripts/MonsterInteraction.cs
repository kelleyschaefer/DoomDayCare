using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterInteraction : MonoBehaviour
{
    public string[] sayings;
    public GameObject dialog_box;
    public Ingredient drop;

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close_Dialog();
        }
    }

    public void Close_Dialog()
    {
        dialog_box.SetActive(false);
    }

    public Ingredient Open_Dialog()
    {
        int i = Random.Range(0, sayings.Length);
        dialog_box.GetComponentInChildren<Text>().text = sayings[i];
        dialog_box.SetActive(true);
        Ingredient ing = null;
        if (Random.Range(1, 5) == 1)
            ing = drop;
        return ing;
    }
}
