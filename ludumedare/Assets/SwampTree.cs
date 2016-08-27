using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwampTree : MonoBehaviour {
	public int energy = 1;
	public int energy_step = 5;
	public GameObject sappling;
	public int TreeMaxPopulation = 20;


	public static int NumberOfTreesLeft()
	{
		return GameObject.FindGameObjectsWithTag("tree").Length;
	}
	public int TreePopulationLimit()
	{
//		lock(m_Handle)
//		{
//			if (TreePopulation < TreeMaxPopulation)
//			{
//				TreePopulation++;
//				Debug.Log("growing more trees:  " + TreePopulation);
//				return 0;
//			}
//			else
//			{
//
//				Debug.Log("Tree population reached");
//				return 1;
//			}
//		}

		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("tree");
		if (gos.Length < TreeMaxPopulation)
		{
			//Debug.Log("growing more trees:  " + gos.Length);
//			foreach (GameObject go in gos)
//			{
//				Debug.Log("go = " + go);
//			}
//			Debug.Log("--------------------------------");
			return 0;
		}
		else
		{
			//Debug.Log("Tree population reached");
			return 1;
		}
	}


	
	// Use this for initialization
	IEnumerator yieldConnect()
	{
		while(true)
		{
			// your code
			energy = energy + energy_step;
			yield return new WaitForSeconds(1);
		}
	}
	// Use this for initialization
	void Start () {

		StartCoroutine(yieldConnect());
	}
	
	// Update is called once per frame
	void Update () {
		if (energy >= 100)
		{
			energy = 1;
//			var healthBar = GameObject.Find("EnergyLevel");
//			Text energyLevelText = healthBar.GetComponent<Text>();
//			energyLevelText.text = "spawn";

			if (TreePopulationLimit() == 0)
			{
				GameObject tree = (GameObject) Instantiate(sappling,transform.position, Quaternion.identity);
//				tree.rigidbody2D.AddRelativeForce(new Vector2(10,6));
				tree.GetComponent<Rigidbody2D>().AddForce(new Vector2(20,20));
				GetComponent<AudioSource>().Play();
			}
			else
			{
//				energyLevelText.text = "max population";
			}
		}
	}
}
