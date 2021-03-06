﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InCombat : MonoBehaviour {
	List<Dictionary<string,string>> weaponsData;
	string currentWeapon = null;
	int weaponHP = 0;
	int npcWeaponHP = 0;
	int playerDamageFromWeapon = 0;
	Text statusLine;
	Text enemyHealth;
	Text myHealth;
	string droppedWeapon;
	bool hotdogUsed = false;

	public bool calculatingDamage = false;

	// Use this for initialization
	void Start () {
		GameState.inBattle = true;
		GameState.currentWeapon = null;
		Debug.Log ("Starting InCombat: " + GameState.weaponsFileName);
		weaponsData = CSVReader.Read (GameState.weaponsFileName);

		//Debug.Log ("phaser = " + CSVReader.FindItem ("phaser", "name", "hp", weaponsData));
//		statusLine = GameObject.Find ("statusLine").GetComponent<UnityEngine.UI.Text> ();
//		statusLine.text = "Starting battle";

//		enemyHealth = GameObject.Find ("EnemyText").GetComponent<UnityEngine.UI.Text> ();
//		myHealth = GameObject.Find ("myhitpoints").GetComponent<UnityEngine.UI.Text> ();
		Debug.Log("battle is " + GameState.currentBattle);
		GameObject.Find (GameState.currentBattle).GetComponent<SpriteRenderer> ().enabled = true;
		activateHUD (true);
		enemyHealth.text = "";
		myHealth.text = "";
		enemyHealth.text = "Enemy:  " + GameState.npcHP;
		myHealth.text = "Health: " + GameState.playerHP;
		statusLine.text = "";

		npcWeaponHP = int.Parse(CSVReader.FindItem("npc", "owner", "hp", weaponsData));
		droppedWeapon = CSVReader.FindItem ("npc", "owner", "name", weaponsData);



	}

	void activateHUD(bool enabled) {
		GameObject.Find ("enemyBoxBorder").GetComponent<Image>().enabled = enabled;
		GameObject.Find ("healthBoxBorder").GetComponent<Image>().enabled = enabled;
		GameObject.Find ("statusboxborder").GetComponent<Image>().enabled = enabled;
		GameObject.Find ("enemystatusbox").GetComponent<Image>().enabled = enabled;
		GameObject.Find ("healthstatusbox").GetComponent<Image>().enabled = enabled;
		GameObject.Find ("statusstatusbox").GetComponent<Image>().enabled = enabled;
		enemyHealth = GameObject.Find ("enemyHealthtext").GetComponent<Text> ();
		enemyHealth.enabled = enabled;
		myHealth = GameObject.Find ("pcHealthtext").GetComponent<Text> ();
		myHealth.enabled = enabled;
		statusLine = GameObject.Find ("statusLineText").GetComponent<Text> ();
		statusLine.enabled = enabled;		
	}
	IEnumerator yieldCalcDamageToNPC()
	{

		statusLine.text = "";
		statusLine.text = "Using the " + currentWeapon + " against the " + GameState.enemyName;
		yield return new WaitForSeconds(1);
		GameState.npcHP = GameState.npcHP - weaponHP;
		enemyHealth.text = "";
		enemyHealth.text = "Enemy:  " + GameState.npcHP;

		if (playerDamageFromWeapon > 0) {
			statusLine.text = "";
			statusLine.text = "Ouch! The " + currentWeapon + " malfunctions and damages you.";
			yield return new WaitForSeconds(1);			
			GameState.playerHP = GameState.playerHP - playerDamageFromWeapon;
			myHealth.text = "";
			myHealth.text = "Health: " + GameState.playerHP;
		}
		// calculate damage

		if (hotdogUsed) {
			hotdogUsed = false;
			statusLine.text = "";
			statusLine.text = "Yum.  Hotdogs increase health!";			
			yield return new WaitForSeconds (1);				
		} else {
			if (weaponHP == 0) {
				statusLine.text = "";
				statusLine.text = "You missed.";			
				yield return new WaitForSeconds (1);	
			}
		}

		if (GameState.npcHP <= 0) {
			yield return new WaitForSeconds(1);
			GameObject.Find ("NpcSpawn").GetComponent<SpriteRenderer> ().enabled = false;
			statusLine.text = "";
			statusLine.text = "You win!!!";
			yield return new WaitForSeconds(1);

			activateHUD (false);
			// and give them the prize.
			GameObject prize = GameObject.Find (droppedWeapon);
			prize.GetComponent<SpriteRenderer> ().enabled = true;
			prize.GetComponent<BoxCollider2D> ().enabled = true;

			// now make an exit door available 
			GameObject exitDoor = GameObject.Find ("exit_door");
			exitDoor.GetComponent<SpriteRenderer> ().enabled = true;
			exitDoor.GetComponent<BoxCollider2D> ().enabled = true;
			exitDoor.GetComponent<exit_combat> ().nextScene = GameState.currentLevel;
			exitDoor.GetComponent<exit_combat> ().currentBattle = GameState.currentBattle;

			// let them out to run to the door
			GameObject.Find ("gate").GetComponent<BoxCollider2D> ().enabled = false;
			calculatingDamage = false;
			GameState.makeInventoryButtonsInteractable (true);			
			GameState.inBattle = false;
		}
		else
		{
			statusLine.text = "";
			statusLine.text = "The enemy damages you.";
			GameState.playerHP = GameState.playerHP - npcWeaponHP;
			Debug.Log ("enemy damaged player");
		}
		// begin npc



		// calculate damage
		yield return new WaitForSeconds(1);


		statusLine.text = "";
		statusLine.text = "Calculating damage...";
		yield return new WaitForSeconds(1);
		myHealth.text = "";
		myHealth.text = "Health: " + GameState.playerHP;
		if (GameState.playerHP <= 0) {
			GameState.gameOver = true;
			yield return new WaitForSeconds (1);
			statusLine.text = "";
			statusLine.text = "You died";
			yield return new WaitForSeconds (1);
			activateHUD (false);
			GameObject.Find ("gate").GetComponent<BoxCollider2D> ().enabled = false;
			GameState.makeInventoryButtonsInteractable (true);	
			calculatingDamage = false;
			GameState.inBattle = false;
			SceneManager.LoadScene ("youdied");
		} else {
			// if you made it this far, you lived to fight again
			statusLine.text = "";
			statusLine.text = "Battle continues.";
			calculatingDamage = false;
			GameState.makeInventoryButtonsInteractable (true);			
		}

		GameState.makeInventoryButtonsInteractable (true);			

	}
	// Update is called once per frame
	void Update () {
	
		if (GameState.currentWeapon != null && !calculatingDamage) {
			calculatingDamage = true;
			currentWeapon = GameState.currentWeapon;
			GameState.currentWeapon = null;
			if (GameState.inBattle) {
				GameState.makeInventoryButtonsInteractable (false);
			}

			// check if hotdog
			if (currentWeapon == "hotdog") {
				Debug.Log ("yum.  hotdog good");
				hotdogUsed = true;

				myHealth.text = "";
				myHealth.text = "Health: " + GameState.playerHP;
			}
				
			// start the battle
			Debug.Log ("Selected " + currentWeapon);
			weaponHP = int.Parse (CSVReader.FindItem (currentWeapon, "name", "hp", weaponsData));
			playerDamageFromWeapon = int.Parse (CSVReader.FindItem (currentWeapon, "name", "player_damage", weaponsData));

			StartCoroutine (yieldCalcDamageToNPC ());

		} else {
			GameState.currentWeapon = null;
		}

		// 
	}
}
