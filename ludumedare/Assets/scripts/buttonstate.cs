﻿using UnityEngine;
using System.Collections;

public class buttonstate : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // TODO: use this for initialization
		Debug.Log("loading inventorycell");
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
        GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("Sprites/sword");
    }
    public void setButtonImage()
    {
        GetComponent<UnityEngine.UI.Button>().image.sprite = Resources.Load<Sprite>("Sprites/phone");
    }
	

}
