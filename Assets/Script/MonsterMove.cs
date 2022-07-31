using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour {

	private float x, y;
	private bool turn;
	public GameObject mon;
	public GameObject explodeSound;
	public GameObject explodeBong;


	void Start()
	{
		turn = false;
	}

	// Update is called once per frame
	void Update () {

		//monster.GetComponent<Rigidbody2D> ().velocity = new Vector2(5,0);

		//transform.Translate( Vector2.up * 6f * Time.deltaTime); //往上跳

		transform.Translate(Vector2.down * 3f * Time.deltaTime);
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D a)
	{
		GameObject aa = a.gameObject;
		if (aa.name == "Shoot(Clone)")
        {
			if (aa)
            {
                Destroy (aa);
				//AudioSource exploAudio = explodeSound.GetComponent<AudioSource>();
				//exploAudio.Play();
				GameObject exploS = Instantiate (explodeSound, mon.transform.position, Quaternion.identity);
				GameObject exploB = Instantiate (explodeBong, mon.transform.position, Quaternion.identity);
				Destroy (mon);
				Destroy (exploS, 2f);
				Destroy (exploB, 0.6f);
				PressToRun.score++;
            }
        }

		if (aa.name == "DownBorder")
		{
			if (aa)
			{
				Destroy (mon);
			}
		}
	}
}