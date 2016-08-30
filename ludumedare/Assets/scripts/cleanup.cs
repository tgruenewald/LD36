using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameState.gameOver = true;
		for (int i = 0; i< Player.MAX_INVENTORY; i++) {
			Button inventorySlot = GameObject.Find ("InventoryButton" + (i+1)).GetComponent<UnityEngine.UI.Button> ();

			inventorySlot.tag = "available";
			inventorySlot.image.sprite = Resources.Load<Sprite>("Sprites/inventorycell");
			if (i >= Player.MAX_INVENTORY) {
				i = 0;
			}			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
