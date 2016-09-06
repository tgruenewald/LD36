using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class exit_combat : MonoBehaviour {

	public string nextScene;
	public string currentBattle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		//		GameState.droplet = coll.gameObject;
		//		AudioClip clip = Resources.Load("sound/ld35_jungle_v2") as AudioClip;
		//		AudioSource[] audios = GameState.droplet.GetComponents<AudioSource>();
		//
		//		audios[0].Stop();
		//		audios[0].clip = clip;
		//		audios[0].Play();
		//GameState.currentLevel = "jungle";
		GameObject.Find (currentBattle).GetComponent<SpriteRenderer> ().enabled = false;
		SceneManager.LoadScene (nextScene);


	}
}
