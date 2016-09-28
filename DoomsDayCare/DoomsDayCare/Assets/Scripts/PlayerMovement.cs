using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 5.0f;
    public GameObject mixing_menu;
    private Vector3 onscreen;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Cauldron"))
        {
            Open_Cauldron();
        }
        else if(coll.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            coll.gameObject.GetComponent<MonsterInteraction>().Open_Dialog();
        }
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close_Cauldron();
        }
    }

    void Start()
    {
        onscreen = mixing_menu.transform.localPosition;
        Close_Cauldron();
    }

    void Update()
    {
        Move();
    }

    private void Open_Cauldron()
    {
        mixing_menu.transform.localPosition = onscreen;
    }

    private void Close_Cauldron()
    {
        mixing_menu.transform.localPosition = new Vector3(1000, 1000, 0);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.DownArrow)) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.UpArrow)) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
