using UnityEngine;
using System.Collections;

public class Z_Projectile : MonoBehaviour
{
    private float speed = 5.0f;
    public GameObject manager;
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.localPosition.y < 10)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Destroy(coll.gameObject);
            manager.GetComponent<Z_Manager>().Remove_Zombie(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
