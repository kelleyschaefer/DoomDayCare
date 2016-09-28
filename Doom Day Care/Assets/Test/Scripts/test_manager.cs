using UnityEngine;
using System.Collections;

public class test_manager : MonoBehaviour
{
    public GameObject cauldron_menu;

    private Vector3 off_screen = new Vector3(1000, 1000, 0);
    private Vector3 on_screen;

    public GameObject phoenix;
    private Vector3 p_on;

    void Start()
    {
        p_on = phoenix.transform.localPosition;
        on_screen = cauldron_menu.transform.localPosition;
        CloseCauldron();
        ClosePhoenix();
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCauldron();
            ClosePhoenix();
        }
    }

    public void OpenPhoenix()
    {
        phoenix.transform.localPosition = p_on;
    }

    public void ClosePhoenix()
    {
        phoenix.transform.localPosition = off_screen;
    }

    public void OpenCauldron()
    {
        cauldron_menu.transform.localPosition = on_screen;
    }

    public void CloseCauldron()
    {
        cauldron_menu.transform.localPosition = off_screen;
    }
}
