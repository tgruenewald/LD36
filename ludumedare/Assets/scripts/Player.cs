﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
public class Player : MonoBehaviour {
	public static int max_number_of_walls = 15;
	public const int MAX_INVENTORY = 4;  // real max of 14
	public float speed = 20f;
	public int energy = 20;
	public int energy_step = 5;
	public Interactions Interactions;
	GameObject healthBar;
	GameObject scoreText;
	GameObject prevBrick;
	public GameObject prey;
	GameObject energyBar;
	bool ogreIsAboutToDie = false;
	int score = 0;
	private bool facingRight = true;
	public static int InventoryNumber = 0;
	public static Button[] InventoryArray = new Button[MAX_INVENTORY];
	static bool created = false;
	private static Player playerInstance;
	private string[] weapons = {
		"phaser", 
		"sword",
		"club",
		"rock",
		"rifle",
		"crossbow",
		"grenade",
		"sling",
		"spear",
		"hotdog",
		"crystal"
	};

	IEnumerator yieldConnect()
	{
		while(true)
		{
			// your code
			if (energy >= 0)
			{
				energy = energy - energy_step;
			}
			Image img = energyBar.GetComponent<Image>();
			img.fillAmount = img.fillAmount - .01f * energy_step;

			if (energy > 0)
			{
				scoreText = GameObject.Find("ScoreText");
				Text t = scoreText.GetComponent<Text>();
				t.text = "" + score++;
			}
			//Debug.Log("fill amount " + img.fillAmount);
			yield return new WaitForSeconds(1);
		}
	}

	void Awake() {
		DontDestroyOnLoad (gameObject);
		if (playerInstance == null) {
			playerInstance = this;
		} else {
			DestroyObject(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
//		var brickText = GameObject.Find("BrickText");
		Debug.Log ("Player start:  inventory = " + InventoryNumber);
		GameState.player = gameObject;
		// repopulate the inventory
//		for (int i = 0; i< InventoryNumber; i++) {
//			Button inventorySlot = GameObject.Find ("InventoryButton" + (i+1)).GetComponent<UnityEngine.UI.Button> ();
//
//			inventorySlot.tag = InventoryArray[i].tag;
//			inventorySlot.image.sprite = InventoryArray[i].image.sprite;//b.GetComponent<SpriteRenderer>().sprite;//Resources.Load<Sprite>("Sprites/sword");
//			if (i >= MAX_INVENTORY) {
//				i = 0;
//			}			
//		}
			

		score = 0;
		ogreIsAboutToDie = false;

//		healthBar = GameObject.Find("EnergyLevel");
//
//		energyLevelText.text = "" + energy;
//
//		energyBar = GameObject.Find("EnergyBar");
//		Image img = energyBar.GetComponent<Image>();
//		img.fillAmount = 1f;
//		StartCoroutine(yieldConnect());
	}
	void OnCollisionEnter2D(Collision2D col)
	{
//		if (col.gameObject.tag == "prey")
//		{
//			//AudioSource.PlayClipAtPoint(prey.audio.clip, transform.position);
//			prey.GetComponent<AudioSource>().Play();
//			Destroy(col.gameObject);  
////			Image img = healthBar.GetComponent<Image>();
////			img.fillAmount =  img.fillAmount + 0.2f;
//			energy = energy + energy_step;			
//			Text energyLevelText = healthBar.GetComponent<Text>();
//			energyLevelText.text = "" + energy;
//			Image img = energyBar.GetComponent<Image>();
//			img.fillAmount = img.fillAmount + .01f * energy_step;
//
//
//
//
//		}
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		var tag = coll.gameObject.tag;
		if (tag == "portkey") {
			// don't inventory the portal itself
			return;
		}

         
		if (weapons.Contains (tag)) {

			// only add items to inventory
			Button inventorySlot = GameObject.Find ("InventoryButton" + (InventoryNumber + 1)).GetComponent<UnityEngine.UI.Button> ();
			inventorySlot.tag = tag;
			Debug.Log ("tag getting assigned " + tag);
			inventorySlot.image.sprite = coll.gameObject.GetComponent<SpriteRenderer> ().sprite;//Resources.Load<Sprite>("Sprites/sword");
			InventoryArray [InventoryNumber] = inventorySlot;
			InventoryNumber++;
			if (InventoryNumber >= MAX_INVENTORY) {
				InventoryNumber = 0;
			}

			DestroyObject (coll.gameObject);
		}



	}
	void Flip()
	{
		//Debug.Log("switching...");
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
//		transform.rotation = rot;
//		transform.eulerAngles = new Vector3(0,0, transform.eulerAngles.z);
//		GetComponent<Rigidbody2D>().angularVelocity = 0;

//		float input = Input.GetAxis("Vertical");
//		GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);

		if (!Interactions.inDialogue) {
			
			float movex = Input.GetAxis ("Horizontal");
			float movey = Input.GetAxis ("Vertical");
			// anim.SetFloat("Speed", Mathf.Abs(move));
			if (movex > 0 && !facingRight) {
				Flip ();
			} else if (movex < 0 && facingRight) {
				Flip ();
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (movex * 3f, movey * 3f);
			//		if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) // left or right
			//		{
			//			if (Wall.NumberOfWallsLeft() <= max_number_of_walls)
			//			{
			//				var brickText = GameObject.Find("BrickText");
			//				Text t = brickText.GetComponent<Text>();
			//				
			//				t.text = "" + (max_number_of_walls - Wall.NumberOfWallsLeft());
			//
			//				Vector3 offset = new Vector3(-.1f,.1f,0f);
			//				GameObject newBrick = (GameObject) Instantiate(brick,transform.position - offset	,transform.rotation);
			//				Physics2D.IgnoreCollision(newBrick.GetComponent<Collider2D>(), GetComponent<Collider2D>(),true);
			//				if (prevBrick != null)
			//				{
			//					Physics2D.IgnoreCollision(newBrick.GetComponent<Collider2D>(), prevBrick.GetComponent<Collider2D>(),true);
			//				}
			//				prevBrick = newBrick;
			//
			//			}
			//			//				tree.rigidbody2D.AddRelativeForce(new Vector2(10,6));
			//			//newBrick.rigidbody2D.AddForce(new Vector2(20,20));
			//		}


		}
	}
}
