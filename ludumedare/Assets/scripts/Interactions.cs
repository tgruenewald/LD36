using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {

	public Image textbg;
	public Text storytext;
	public bool inDialogue = false;
	public bool printingText = false;
	private float fadeInTime = 0.025F;

	// Use this for initialization

	void Start () {
		//showText ("Here is some text.");
	}
	
	// Update is called once per frame
	public void Update(){
		if (Input.GetButtonDown ("Fire1")||Input.GetButtonDown("Jump")) {
			//Debug.Log ("clicked");
			if (inDialogue) {
				inDialogue = false;
				//Debug.Log ("hiding text");
				hideText ();

			} 
		}//if click
	}//if Update


	public void showText(string tag){
		//Debug.Log ("showing text: " + dialoguetext);
		textbg.enabled = true;
		StartCoroutine (animate (textManager(tag)));

	}

	public void hideText (){
		textbg.enabled = false;
		storytext.enabled = false;
	}

	public IEnumerator animate(string strComplete){
		printingText = true;
		int i = 0;
		storytext.text = "";
		storytext.enabled = true;
		while( i < strComplete.Length && printingText){
			storytext.text += strComplete[i++];
			yield return new WaitForSeconds(fadeInTime);
		}
		storytext.text = strComplete;
		printingText = false;
		inDialogue = true;
	}

	public string textManager(string tag)
	{
		switch(tag)
		{
		case "idalia":
			return "Idalia never shuts up.";
		case "whale":
			return "This is a whale of a problem.";
		default:
			return "textManager did not find string";
		}
	}
}
