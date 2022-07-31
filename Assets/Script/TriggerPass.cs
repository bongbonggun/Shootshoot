using UnityEngine;
using System.Collections;

public class TriggerPass : MonoBehaviour {

	// Use this for initialization
	public GameObject pf;

	void OnTriggerEnter2D (Collider2D a)
	{
		if (a.gameObject.name == "StickMan")
		{
			pf.SetActive (false);
		}
	}
}
