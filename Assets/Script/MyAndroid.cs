using UnityEngine;
using System.Collections;

public class MyAndroid : MonoBehaviour
 {
	void Start () 
	{
	}
	void Update () 
	{
	}

	void OnGUI()
    {
		#if UNITY_ANDROID && !UNITY_EDITOR
		Rect rect = new Rect( Screen.width - (Screen.width/8), Screen.height-(Screen.height/8), Screen.width / 10, Screen.height / 10 );
        if ( GUI.Button(rect, "呼叫 Android") )
        {
            using ( AndroidJavaClass unity = new AndroidJavaClass("com.example.bongbonggun.myapplication.MyDialog") )
            {
                unity.CallStatic( "Show", "這是標題", "這是內文" );
            }
        }
		#endif
    }
}

