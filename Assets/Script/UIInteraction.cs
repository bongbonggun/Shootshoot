using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteraction : MonoBehaviour {

	public GameObject txtAt;

	// Use this for initialization
	void Start () 
	{
		if (txtAt)
		{
			txtAt.SetActive (false);
		}	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void BtnStart()
	{
		SceneManager.LoadScene("test");
	}

	public void BtnExit()
	{
		Application.Quit();
	}

	public void BtnSecret()
	{
		if (txtAt) 
		{
			txtAt.SetActive (true);
		}
	}

	public void BtnAt()
	{
		SceneManager.LoadScene ("hint");
	}

	public void BtnMenu()
	{
		SceneManager.LoadScene ("menu");
	}
}
