using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public GameObject mon;

	void OnTriggerEnter2D(Collider2D a)
	{
		if (a.gameObject.name == "StickMan") 
		{
			Instantiate(mon, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
		}
	}
}
