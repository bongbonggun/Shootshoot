using UnityEngine;
using System.Collections;

public class TriggerDeath : MonoBehaviour {

	//public GameObject st;

	void OnTriggerEnter2D (Collider2D a)
	{
		GameObject aa = a.gameObject;
		if (aa.name == "StickMan")
		{
			float x = aa.transform.position.x - 4f;
			float y = aa.transform.position.y + 6f;
			aa.transform.position = new Vector2 (x,y);
			//st.SetActive (false);
			//Instantiate(st, new Vector3(x, y, 0), Quaternion.identity);

		}
	}
}
