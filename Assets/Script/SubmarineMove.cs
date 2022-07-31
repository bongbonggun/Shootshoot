using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubmarineMove : MonoBehaviour {

	private float x, y, orignalPosition;
	private bool turn;
	public GameObject sub;
	public Text txt;

	// Use this for initialization
	void Start () {
		turn = false;
		//sub.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		orignalPosition = transform.position.y;
		txt.text = orignalPosition.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (turn == false) 
		{
			transform.Translate (Vector2.down * 0.4f * Time.deltaTime);
			if (Mathf.Abs (transform.position.y - orignalPosition) > 0.6) 
			{
				turn = true;
				orignalPosition = transform.position.y;
			}	
		} 
		else 
		{
			transform.Translate (Vector2.up * 0.4f * Time.deltaTime);
			if (Mathf.Abs (transform.position.y - orignalPosition) > 0.6)
			{
				turn = false;
				orignalPosition = transform.position.y;
			}	
		}

	}
}
