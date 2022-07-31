using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBorn : MonoBehaviour {

	public GameObject food, foodGolden;
	private float x, y;
	private int chance;
	private bool spawn;

	// Use this for initialization
	void Start ()
	{
//		Born ();
		InvokeRepeating("Born", 0, 5f);
	}

	// Update is called once per frame
	void Update ()
	{
		// If Food is been eaten, spawn food
//		if (!GameObject.Find ("Food(Clone)") && !GameObject.Find ("FoodGolden(Clone)"))
//		{
//			Born ();
//		}
	}

	IEnumerator Wait()
	{
		float rand = Random.Range (1f, 30f);
		yield return new WaitForSeconds (rand);
	}

	void Born()
	{
		// Random spawn position
		if (!GameObject.Find ("Food(Clone)") && !GameObject.Find ("FoodGolden(Clone)")) 
		{

			x = Random.Range (-6, 6);
			y = Random.Range (-4, 4);

			//1/1000 chance to spawn golden key
			chance = Random.Range (1, 100);
			if (chance != 1) {
				GameObject fd = Instantiate (foodGolden, new Vector3 (5.5f, 3.5f, 0), Quaternion.identity);
			} else {
				GameObject fd = Instantiate (food, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}
}