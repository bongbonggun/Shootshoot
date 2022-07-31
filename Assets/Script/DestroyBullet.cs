using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyBullet : MonoBehaviour {

	public GameObject shoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D a)
	{
		GameObject aa = a.gameObject;
		if (aa.name == "UpBorder") 
		{
			if (aa)
			{
				Destroy (shoot);
			}
		}
	}
}
