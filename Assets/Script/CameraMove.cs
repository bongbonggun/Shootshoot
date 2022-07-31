using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public GameObject target;
	private float cameraMoveTime, aspect;
	private Vector3 cameraVelocity;
	private Camera camera = new Camera();
	private float x, y;
	//private float w=16, h=9;

	// Use this for initialization
	void Start () 
	{
		//st = GameObject.Find ("Stickman");
		cameraMoveTime = 0.2f; //速度越小越快
		cameraVelocity = Vector3.zero;
		camera = Camera.main;
		//mainCamera.aspect= w / h; //camera比
	}
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3.SmoothDamp(transform.position, target.transform.position + new Vector3(x, y, -5), ref cameraVelocity, cameraMoveTime);
	}

}
