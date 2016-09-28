using UnityEngine;
using System.Collections;

public class Cauldron : MonoBehaviour
{

    public GameObject player;
    public GameObject MonsterList;
    public GameObject Monster_World_Prefab;
    public GameObject monster_dialog_box;


	// Use this for initialization
	void Start () {
        monster_dialog_box.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Add_Monster_To_World(Monster m)
    {
        GameObject pf = Monster_World_Prefab;
        pf.GetComponent<Animator>().runtimeAnimatorController = m.controller;
        pf.GetComponent<MonsterInteraction>().sayings = m.sayings;
        pf.GetComponent<MonsterInteraction>().drop = m.drop;
        pf.GetComponent<MonsterInteraction>().dialog_box = monster_dialog_box;
        Vector3 location = new Vector3(Random.Range(-14, -6), Random.Range(-7, 3), 0);
        GameObject go = (GameObject)Instantiate(pf, location, Quaternion.identity);
    }
}
