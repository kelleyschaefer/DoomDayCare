using UnityEngine;
using System.Collections;

public class test_player : MonoBehaviour
{
    private float speed = 5.0f;
    public GameObject manager;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Cauldron"))
        {
            manager.GetComponent<test_manager>().OpenCauldron();
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.localPosition.x > 1)
        {
            GetComponent<Animator>().ResetTrigger("right");
            GetComponent<Animator>().ResetTrigger("up");
            GetComponent<Animator>().ResetTrigger("down");
            GetComponent<Animator>().SetTrigger("left");
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && transform.localPosition.x < 15)
        {
            GetComponent<Animator>().ResetTrigger("left");
            GetComponent<Animator>().ResetTrigger("up");
            GetComponent<Animator>().ResetTrigger("down");
            GetComponent<Animator>().SetTrigger("right");
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (((Input.GetKey(KeyCode.DownArrow)) || Input.GetKey(KeyCode.S)) && transform.localPosition.y > 1)
        {
            GetComponent<Animator>().ResetTrigger("right");
            GetComponent<Animator>().ResetTrigger("up");
            GetComponent<Animator>().ResetTrigger("left");
            GetComponent<Animator>().SetTrigger("down");
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if ((Input.GetKey(KeyCode.UpArrow)) || Input.GetKey(KeyCode.W) && transform.localPosition.y < 14)
        {
            GetComponent<Animator>().ResetTrigger("right");
            GetComponent<Animator>().ResetTrigger("left");
            GetComponent<Animator>().ResetTrigger("down");
            GetComponent<Animator>().SetTrigger("up");
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
