using UnityEngine;
using System.Collections;

public class npc_shark : MonoBehaviour {
	private static npc_shark npcInstance = null;
	// Use this for initialization
	void Start () {
	
	}
	void Awake() {
		DontDestroyOnLoad (gameObject);
		if (npcInstance == null) {
			npcInstance = this;
		} else {
			DestroyObject(gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
