using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wall : MonoBehaviour {

	public int wall_timeout = 10;
	int timeout;
	public int wall_timeout_step = 1;
	GameObject brickText;
	// Use this for initialization

	public static int NumberOfWallsLeft()
	{
		return GameObject.FindGameObjectsWithTag("wall").Length;
	}

	void Start () {
		timeout = wall_timeout;
		brickText = GameObject.Find("BrickText");
		StartCoroutine(yieldConnect());
	}
	IEnumerator yieldConnect()
	{
		while(true)
		{
			// your code
			timeout = timeout - wall_timeout_step;
			yield return new WaitForSeconds(1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Text t = brickText.GetComponent<Text>();
		int wallcount = Wall.NumberOfWallsLeft();
		if (Player.max_number_of_walls - wallcount >= 0)
		{
			t.text = "" + (Player.max_number_of_walls - wallcount);
		}
		if (timeout <= 0)
		{
			timeout = wall_timeout;
			Destroy(gameObject);

		}
	}
}
