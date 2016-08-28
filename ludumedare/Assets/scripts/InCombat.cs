using UnityEngine;
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
	// Use this for initialization
	void Start () {
		Debug.Log ("Starting InCombat: " + GameState.weaponsFileName);
		weaponsData = CSVReader.Read (GameState.weaponsFileName);

		//Debug.Log ("phaser = " + CSVReader.FindItem ("phaser", "name", "hp", weaponsData));
		statusLine = GameObject.Find ("statusLine").GetComponent<UnityEngine.UI.Text> ();
		statusLine.text = "Starting battle";

		enemyHealth = GameObject.Find ("EnemyText").GetComponent<UnityEngine.UI.Text> ();
		myHealth = GameObject.Find ("myhitpoints").GetComponent<UnityEngine.UI.Text> ();
		enemyHealth.text = "";
		myHealth.text = "";
		enemyHealth.text = "Enemy:  " + GameState.npcHP;
		myHealth.text = "Health: " + GameState.playerHP;

		npcWeaponHP = int.Parse(CSVReader.FindItem("npc", "owner", "hp", weaponsData));




	}
	IEnumerator yieldCalcDamageToNPC()
	{
		statusLine.text = "";
		statusLine.text = "Calculating damage that the player did to the bad guy";
		GameState.npcHP = GameState.npcHP - weaponHP;
		enemyHealth.text = "";
		enemyHealth.text = "Enemy:  " + GameState.npcHP;
		// calculate damage
		yield return new WaitForSeconds(2);
		if (GameState.npcHP <= 0) {
			yield return new WaitForSeconds(2);
			statusLine.text = "";
			statusLine.text = "You win!!!";
			yield return new WaitForSeconds(1);
			GameState.makeInventoryButtonsInteractable (true);			
			SceneManager.LoadScene (GameState.currentLevel);
		}

		// begin npc
		if (weaponHP == 0) {
			statusLine.text = "";
			statusLine.text = "You missed";			
			yield return new WaitForSeconds(1);	
		}

		statusLine.text = "";
		statusLine.text = "NPC turn to do damage";
		GameState.playerHP = GameState.playerHP - npcWeaponHP - playerDamageFromWeapon;

		// calculate damage
		yield return new WaitForSeconds(2);


		statusLine.text = "";
		statusLine.text = "Calculating damage that the NPC did";
		yield return new WaitForSeconds(2);
		myHealth.text = "";
		myHealth.text = "Health: " + GameState.playerHP;
		if (GameState.playerHP <= 0) {
			yield return new WaitForSeconds (2);
			statusLine.text = "";
			statusLine.text = "You died";
			yield return new WaitForSeconds (1);
			GameState.makeInventoryButtonsInteractable (true);			
			SceneManager.LoadScene ("youdied");
		} else {
			// if you made it this far, you lived to fight again
			statusLine.text = "";
			statusLine.text = "You live to fight again";
			GameState.makeInventoryButtonsInteractable (true);			
		}



	}
	// Update is called once per frame
	void Update () {
	
		if (GameState.currentWeapon != null) {
			// start the battle
			currentWeapon = GameState.currentWeapon;
			GameState.currentWeapon = null;
			GameState.makeInventoryButtonsInteractable (false);
			Debug.Log ("Selected " + currentWeapon);
			weaponHP = int.Parse(CSVReader.FindItem(currentWeapon, "name", "hp", weaponsData));
			playerDamageFromWeapon = int.Parse(CSVReader.FindItem(currentWeapon, "name", "player_damage", weaponsData));


			StartCoroutine(yieldCalcDamageToNPC());
		}

		// 
	}
}
