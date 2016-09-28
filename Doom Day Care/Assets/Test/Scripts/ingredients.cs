using UnityEngine;
using System.Collections;

public class ingredients : MonoBehaviour
{
    private float speed = 1;
    public GameObject ingredient;
    public Vector3 current_loc;

    public ArrayList ing = new ArrayList();

	// Use this for initialization
	void Start ()
    {
        current_loc = GetComponent<Transform>().localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ing.Count > 0)
        {
            foreach (GameObject go in ing)
            {
                go.transform.LookAt(new Vector3(8, 3, 0));
                go.transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
	}

    public void AddIngredient()
    {
        GameObject go = (GameObject)Instantiate(ingredient, current_loc, Quaternion.identity);
        ing.Add(go);    
    }
}
