﻿using UnityEngine;
using System.Collections;

public class buttonstate : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // TODO: use this for initialization
		//Debug.Log("loading inventorycell");
		GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("sprites/inventorycell");
    }
    public void hover()
    {
        Debug.Log("hover");
        GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("Sprites/broken_mug");
    }
    public void unhover()
    {
        Debug.Log("unhover");
        GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("Sprites/mug");
    }

    public void click()
    {
		Debug.Log ("you clicked");
		GameState.makeInventoryButtonsInteractable (false);
        //GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("Sprites/sword");
		UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button> ();
		Debug.Log ("You selected the " + button.tag);
		GameState.currentWeapon = button.tag;

		if (button.tag == "hotdog" || button.tag == "grenade") {
			button.tag = "available";
			button.image.sprite = Resources.Load<Sprite>("Sprites/inventorycell");

		}

    }
    public void setButtonImage()
    {
        GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("Sprites/phone");
    }
	

}
