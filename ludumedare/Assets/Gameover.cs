using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gameover : MonoBehaviour {

	public void load_level1()
	{
		Application.LoadLevel("level1");
	}
	public void load_credits()
	{
		Application.LoadLevel("credits_level");
	}

	public void load_title()
	{
		Application.LoadLevel("title_level");
	}
	public void load_tut1()
	{
		Application.LoadLevel("tut1_level");
	}
	public void load_tut2()
	{
		Application.LoadLevel("tut2_level");
	}
	public void load_tut3()
	{
		Application.LoadLevel("tut3_level");
	}
	public void load_tut4()
	{
		Application.LoadLevel("tut4_level");
	}
	public void quit_game()
	{
		Application.Quit();
	}
	public static void change_game_over_sign(string component, string sign)
	{
		GameObject canvas = GameObject.Find("Canvas");
		Text[] textValue = canvas.GetComponentsInChildren<Text>();
		foreach(Text text in textValue)
		{
			if (text.name == component)
			{
				text.text = sign;
				break;
			}
		}
	}
	public static void hide_game_over()
	{
		change_game_over_sign("GameOverText", "");
		change_game_over_sign("GameOverExplainText", "");

	}
	public static void game_over(string explaination)
	{
//		Application.LoadLevel("gameover");
		change_game_over_sign("GameOverText","Game Over");
		change_game_over_sign("GameOverExplainText", explaination);

	}
}
