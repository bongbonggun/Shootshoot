using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class CameraClamp : MonoBehaviour {

	[SerializeField]Transform target;
	[SerializeField]float xMin = -1;
	[SerializeField]float xMax = 1;
	[SerializeField]float yMin = -1;
	[SerializeField]float yMax = 1;

	Transform t;

	void Awake() //Awake()會比Start()還要優先
	{ 
		t = transform;
	}

	void LateUpdate() //LateUpdate()會比Update()還要後面
	{ 
		float x = Mathf.Clamp (target.position.x, xMin, xMax);
		float y = Mathf.Clamp (target.position.y, yMin, yMax);
		t.position = new Vector3 (x, y, -1); //z設定-1是為了讓圖層出現看的見
	}
}