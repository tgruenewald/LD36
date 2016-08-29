using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartCombat : MonoBehaviour {
	public string weaponsFileName;
	public string npcImageName;
	public int npcHP;
	public string currentLevel;
	public string currentBattle;
	public string music;

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

		Debug.Log ("Calling combat scene");
		GameState.weaponsFileName = weaponsFileName;
		GameState.npcImageName = npcImageName;
		GameState.music = music;

		GameState.npcHP = npcHP;
		GameState.currentLevel = currentLevel;
		GameState.currentBattle = currentBattle;
		SceneManager.LoadScene ("generic_fight");


	}
}
