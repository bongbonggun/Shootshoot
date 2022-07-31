using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	public GameObject target;

	void OnTriggerStay2D(Collider2D a)
	{
		GameObject aa = a.gameObject;
		if (aa.name == "StickMan")
		{
			aa.GetComponent<Rigidbody2D>().gravityScale = 0f;
			aa.GetComponent<PressToRun> ().isSwim = true;

				//aa.transform.Translate(Vector2.up * 0.5f * Time.deltaTime);
				//aa.transform.Translate(Vector2.down * 0.5f * Time.deltaTime);

		} 
	}

	void OnTriggerExit2D(Collider2D a)
	{
		GameObject aa = a.gameObject;
		if (aa.name == "StickMan")
		{
			aa.GetComponent<Rigidbody2D>().gravityScale = 1f; 
			aa.GetComponent<PressToRun> ().isSwim = false;
		} 
	}
}