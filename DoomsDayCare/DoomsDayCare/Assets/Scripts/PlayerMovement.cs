using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 5.0f;
    //public GameObject manager;

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.layer == LayerMask.NameToLayer("Cauldron"))
    //    {
    //        manager.GetComponent<test_manager>().OpenCauldron();
    //    }
    //}

    void Update()
    {
        Move();
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
