using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondBackGroundMove : MonoBehaviour {

	public GameObject At;
	public float x, y, z;
	public Text txtRGBA;
	private float r, g, b, a;

	// Use this for initialization
	void Start () 
	{
//		r = 100f;
//		g = 100f;
//		b = 100f;
//		a = 50f;
//		At.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, a);
//		InvokeRepeating ("ColorChange", 0.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		At.transform.Rotate(x, y, z);
	}

	void ColorChange()
	{
		txtRGBA.text = r.ToString() + ";" + g.ToString() + ";" + b.ToString() + ";" + a.ToString();
		r = Random.Range (0, 255);
		g = Random.Range (0, 255);
		b = Random.Range (0, 255);
		a = Random.Range (0, 255);
		At.GetComponent<SpriteRenderer>().material.color = new Color(r, g, b, a);
	}
}
