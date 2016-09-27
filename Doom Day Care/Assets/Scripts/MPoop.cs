using UnityEngine;
using System.Collections;

public class MPoop : MonoBehaviour {

    public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void sendItem()
    {
        GameObject iProj = Instantiate(projectile) as GameObject;
    }
}
