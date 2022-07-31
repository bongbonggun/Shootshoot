using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {

	private Rect start, rule, exit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		start = new Rect( Screen.width/2, Screen.height/6, Screen.width / 5, Screen.height / 5 );
		rule = new Rect( Screen.width/2, Screen.height/6*2, Screen.width / 5, Screen.height / 5 );
		exit = new Rect( Screen.width/2, Screen.height/6*3, Screen.width / 5, Screen.height / 5 );

		GUIStyle ButtonStyle = new GUIStyle(GUI.skin.button);
		ButtonStyle.fontSize = 10; //設定按鈕的文字大小

		if ( GUI.Button(start, "開始", ButtonStyle) )
		{
			SceneManager.LoadScene("testlevel");
		}
		else if ( GUI.Button(rule, "規則", ButtonStyle) )
		{

		}
		else if ( GUI.Button(exit, "離開", ButtonStyle) )
		{
			Application.Quit ();
		}
	}
}
