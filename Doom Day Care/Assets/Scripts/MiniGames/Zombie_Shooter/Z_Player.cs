using UnityEngine;
using System.Collections;

public class Z_Player : MonoBehaviour
{
    public GameObject manager;
    private float speed = 5.0f;

    void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // shoot
            Debug.Log("Shoot!");
            manager.GetComponent<Z_Manager>().Fire();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            manager.GetComponent<Z_Manager>().Game_Over(false);
        }
    }

    private void Move()
    {
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.localPosition.x > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.localPosition.x < 17)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
