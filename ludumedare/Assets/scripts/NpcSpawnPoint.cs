using UnityEngine;
using System.Collections;

public class NpcSpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Npc spawn point");
		gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> (GameState.npcImageName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
