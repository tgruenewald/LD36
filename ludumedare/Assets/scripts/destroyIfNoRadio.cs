using UnityEngine;
using System.Collections;

public class destroyIfNoRadio : MonoBehaviour {

	Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("judy").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
		if (!player.hasRadio)
		{
			DestroyObject (this.gameObject);
		}
	}
}
