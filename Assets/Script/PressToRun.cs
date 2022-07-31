/*
移動:左 右 跳
水中移動:上 下 左 右
發射
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressToRun : MonoBehaviour {

    public Animator Anim;
	public GameObject st, shoot, explodeSound, explodeBong, foodSound;
	public Text txt, txtTime, txtScore, txtWord, txtRestart, txtEat; // UI text
	public float run, jp, swim;
	public static int score; // Killing score
	public int food; 
	public bool isSwim;

	private Rect right, left, jump, esc; 
	private bool isSceneTime, isSecretEgg, isRestart;
	private float x, y, totalTime, timeExplo;
	private string Endwords;


    void Start ()
	{
		//xt = GameObject.Find ("Text").GetComponent<Text> ();
		//st = GameObject.Find ("a1");
		//OnGUI();
		run = 8f;
		swim = 4f;
		jp = 6f;
		score = 0;
		food = 0;
		isSwim = false;
		isSceneTime = false;
		isSecretEgg = false;
		isRestart = false;
		txtScore.text = "";
		txtWord.text = "";
		txtRestart.text = "";
		txtEat.text="";
	}

	// Update is called once per frame
	void Update () 
	{
		txt.text = st.transform.position.x.ToString() + ", " + st.transform.position.y.ToString(); // 顯示x,y
		totalTime += Time.deltaTime; // 總時間
		txtTime.text = totalTime.ToString(); // 顯示總時間

		// If die, back to scene "menu"
		if (isSceneTime)
		{
			if (isRestart)
			{
				if (Input.GetKeyDown (KeyCode.Space)) 
				{
					SceneManager.LoadScene ("test");
				}
			}
			//StartCoroutine("LoadMenu");
		}
		else
		{
			ComInput ();
			Shoot ();
		}
			
		//Press ESC to menu
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			SceneManager.LoadScene ("menu");
		}
	}
		

	IEnumerator WaitForText()
	{
		yield return new WaitForSeconds(1f);

		if (score < 1000)
		{
			txtScore.text = "YOU'VE STABBED " + score;
		}
		else
		{
			txtScore.text = "YOU ARE ABSOLUTELY POSEIDON(Ψ)";
		}

		yield return new WaitForSeconds(1f);

		if (score < 1000)
		{
			txtEat.text = "EATEN " + food;
		}
		else
		{
			txtEat.text = "AMAZING GASTRONOME"; //美食家
		}

		yield return new WaitForSeconds(1f);

		txtWord.text = Endwords;

		yield return new WaitForSeconds(1f);

		txtRestart.text = "PRESS SPACE TO RESTART";

		isRestart = true;
		//SceneManager.LoadScene("menu");
	}

	IEnumerator LoadMeunu()
	{
		yield return new WaitForSeconds(1f);
		//SceneManager.LoadScene("menu");
	}

	void OnTriggerEnter2D (Collider2D a)
	{
		GameObject aa = a.gameObject;

		if (aa.name == "Food(Clone)" && isSecretEgg == false)
		{
			food++;
			Destroy (aa);
			GameObject fs = Instantiate (foodSound, st.transform.position, Quaternion.identity);
			Destroy (fs, 2f);
		}
		else if (aa.name == "FoodGolden(Clone)" && isSecretEgg == false)
		{
			food++;
			Destroy (aa);
			GameObject fs = Instantiate (foodSound, st.transform.position, Quaternion.identity);
			Destroy (fs, 2f);
			isSecretEgg = true;
			st.GetComponent<SpriteRenderer> ().color = Color.gray;
			//Debug.Log ("isSecretEgg = " + isSecretEgg);
		}
		else if (aa.name == "SecondBackGround" && isSecretEgg == true)
		{
			//Debug.Log ("Trigger!");
			food++;
			Destroy (aa);
			GameObject fs = Instantiate (foodSound, st.transform.position, Quaternion.identity);
			Destroy (fs, 2f);
			isSceneTime = true;
			Endwords = "THE SECRET HAS BEEN FOUND!";
			StartCoroutine ("WaitForText");
		}
		else if (aa.name == "Monster(Clone)" && isSecretEgg == false)
		{
			if (aa)
			{
				GameObject exploS = Instantiate (explodeSound, st.transform.position, Quaternion.identity);
				GameObject exploB = Instantiate (explodeBong, st.transform.position, Quaternion.identity);
				st.GetComponent<SpriteRenderer> ().sprite = null;
				st.GetComponent<BoxCollider2D> ().enabled = false;
				//shoot.GetComponent<SpriteRenderer> ().sprite = null;
				Destroy (exploS, 2f);
				Destroy (exploB, 0.5f);
				isSceneTime = true;

				if (score > 900) 
				{
					Endwords = "AMAZING STABBER!!";
				}
				else if (score > 800) 
				{
					Endwords = "\"SHOOTING\" STAR!";
				}
				else if (score > 700)
				{
					Endwords = "YOU KILLED IT";
				}
				else if (score > 600) 
				{
					Endwords = "EXCELLENT";
				}
				else if (score > 500)
				{
					Endwords = "GREAT";
				}
				else if (score > 400)
				{
					Endwords = "GOOD";
				}
				else if (score > 300)
				{
					Endwords = "NOT BAD";
				}
				else if (score == 5)
				{
					Endwords = "GIVE ME Phi(Φ)";
				}
				else if (score == 0)
				{
					Endwords = "WTF?";
				}
				else
				{
					int num = Random.Range (1, 17);
					switch (num)
					{
					case 1:
						Endwords = "SO DISAPPOINTING";
						break;
					case 2:
						Endwords = "LOOK AT THIS MESS";
						break;
					case 3:
						Endwords = "ARE YOU SLEEPING?"; 
						break;
					case 4:
						Endwords = "MY GRANDMA CAN DO BETTER THAN YOU";
						break;
					case 5:
						Endwords = "OH MAN"; 
						break;
					case 6:
						Endwords = "TIP: PRESS THE KEYBOARD";
						break;
					case 7:
						Endwords = "LOSE YOUR INFINITY GEMS?";
						break;
					case 8:
						Endwords = "OOOOOOOOPS";
						break;
					case 9:
						Endwords = "IS IT HARD TO SHOOT?";
						break;
					case 10:
						Endwords = "PROGRESS TO SPACE INVADERS MASTER: 0.01%";
						break;
					case 11:
						Endwords = "MISSING TRIDENT";
						break;
					case 12:
						Endwords = "STEP 1: OPEN THE SCREEN";
						break;
					case 13:
						Endwords = "SAY HELLO TO RESTART";
						break;
					case 14:
						Endwords = "EVERYTHING'S GONNA BE ALRIGHT";
						break;
					case 15:
						Endwords = "MISSING 23rd OF THE GREEK ALPHABET";
						break;
					case 16:
						Endwords = "REMEMBER, YOU'RE NOT THE MASERATI";
						break;
					case 17:
						Endwords = "HMMMM, SKIP ELECTROMAGNETISM LESSON?";
						break;
					}
				}
				StartCoroutine ("WaitForText");
			}
		}
	}

    void ComInput()
	{
		if (Input.GetKey(KeyCode.LeftArrow)) //往左跑
		{
			//Anim.SetInteger("Run", 1);
			transform.Translate(Vector2.left * run * Time.deltaTime); //Time.deltaTime 可以減少速度
			//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0); 
		}
		else if (Input.GetKey(KeyCode.RightArrow)) //往右跑
		{
			//Anim.SetInteger("Run", 2);
			transform.Translate(Vector2.right * run * Time.deltaTime);
		}
        else if (Input.GetKey(KeyCode.UpArrow)) //往上游
        {
            transform.Translate(Vector2.up * run * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //往下游
        {
            transform.Translate(Vector2.down * run * Time.deltaTime);
        }
    }

	void SwimInput()
	{
		//Anim.SetInteger("Run", 0);
		if (Input.GetKey(KeyCode.LeftArrow)) //往左游
		{
			transform.Translate(Vector2.left * swim * Time.deltaTime); //Time.deltaTime 可以減少速度
			//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0); 
		}
		if (Input.GetKey(KeyCode.RightArrow)) //往右游
		{
			transform.Translate(Vector2.right * swim * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.UpArrow)) //往上游
		{
			transform.Translate(Vector2.up * swim * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow)) //往下游
		{
			transform.Translate(Vector2.down * swim * Time.deltaTime);
		}
	}
		
	void Shoot()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
            GameObject go = (GameObject) Instantiate(shoot, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity); //發射子彈
			go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 10); //子彈的速度
			Destroy(go, 1.5f); //子彈射出一段時間後自動刪除
		}
	}

	void OnGUI()
	{
		//esc = new Rect( Screen.width/32, Screen.height/32, Screen.width / 10, Screen.height / 10 );

		//GUIStyle ButtonStyle = new GUIStyle(GUI.skin.button);
		//ButtonStyle.fontSize = 10; //設定按鈕的文字大小

		//if (GUI.Button(esc, "選單", ButtonStyle)) //選單
		//{
		//	SceneManager.LoadScene("menu");
		//}

		#if UNITY_ANDROID && !UNITY_EDITOR
		right = new Rect( Screen.width - (Screen.width/8), Screen.height-(Screen.height/8), Screen.width / 10, Screen.height / 10 );
		left = new Rect( Screen.width - (Screen.width/8)*2, Screen.height-(Screen.height/8), Screen.width / 10, Screen.height / 10 );
		jump = new Rect( Screen.width/32, Screen.height-(Screen.height/8), Screen.width / 10, Screen.height / 10 );


		if ( GUI.Button(right, "右", ButtonStyle) ) //向右
		{
			Anim.SetInteger("Run", 2);
			transform.Translate(Vector2.right * 8f * Time.deltaTime);
			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
		}
		else if ( GUI.Button(left, "左", ButtonStyle) ) //向左
		{
			Anim.SetInteger("Run", 1);
			transform.Translate(Vector2.left * 8f * Time.deltaTime); //Time.deltaTime 可以減少速度
			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0); 
		}
		else
		{
			Anim.SetInteger("Run", 0);
		}
		
		if (GUI.Button(jump, "跳", ButtonStyle)) //跳
		{
			transform.Translate(Vector2.up * 6f * Time.deltaTime);
		}
		#endif
	}	
}