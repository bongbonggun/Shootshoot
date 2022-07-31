using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBorn : MonoBehaviour {

    public GameObject mon;
    private float x, y;

	// Use this for initialization
	void Start ()
    {
        y = 4.5F;
        InvokeRepeating("Born", 0, 0.3f);
    }

    void Born()
    {
        x = Random.Range(-6, 6);
        Instantiate(mon, new Vector3(x, y, 0), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
