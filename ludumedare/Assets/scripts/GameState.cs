using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class GameState
{
    public static GameObject player = null;
	public static int playerHP = 100;
    public static GameObject introMusic = null;
    public static string currentLevel = "Scene1";
	public static string weaponsFileName = null;
	public static string currentWeapon = null;
	public static string npcImageName = null;
	public static int npcHP = 0;


	public static void makeInventoryButtonsInteractable(bool enable) {
		for (int i = 0; i< Player.InventoryNumber; i++) {
			Button inventorySlot = GameObject.Find ("InventoryButton" + (i+1)).GetComponent<UnityEngine.UI.Button> ();
			inventorySlot.interactable = enable;
		}		
	}

}


