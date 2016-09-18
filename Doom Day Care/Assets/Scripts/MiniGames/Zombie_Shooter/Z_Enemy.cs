using UnityEngine;
using System.Collections;

public class Z_Enemy : MonoBehaviour
{
    private float speed = 1.0f;
    public GameObject player;
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
