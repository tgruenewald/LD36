using UnityEngine;
using System.Collections;

public class Prey : MonoBehaviour {
	public float speed = 100;
	public int energy = 100;
	public int energy_step = 1;
	public int eat_energy = 33;
	public int initial_energy = 50;
	public GameObject baby;

	public int PreyMaxPopulation = 30;
	public static int NumberOfPreyLeft()
	{
		return GameObject.FindGameObjectsWithTag("prey").Length;
	}
	public int PreyPopulationLimit()
	{
//		lock(m_Handle)
//		{
//			if (PreyPopulation < PreyMaxPopulation)
//			{
//				PreyPopulation++;
//				return 0;
//			}
//			else
//			{
//				return 1;
//			}
//		}
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("prey");
		if (gos.Length < PreyMaxPopulation)
		{
			//Debug.Log("growing more trees:  " + gos.Length + 1);
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
			energy = energy - energy_step;  
			yield return new WaitForSeconds(1);
		}
	}

	void Start () {
//		Vector3 torque;
//
//			torque.x = Random.Range (-200, 200);
//			torque.y = Random.Range (-200, 200);
//			//torque.z = Random.Range (-200, 200);
//			constantForce.torque = torque;
//			rigidbody2D.AddForce(Vector3.up * Random.Range(2, 5), ForceMode.Impulse);
		//rigidbody2D.velocity = new Vector3(Random.Range(-1*speed,speed),Random.Range(-1*speed,speed), 0); 
		//rigidbody2D.AddForce(new Vector2(Random.Range(-1*speed, speed), Random.Range(-1*speed, speed)));
		GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1*speed, speed), Random.Range(-1*speed, speed)));
		StartCoroutine(yieldConnect());
		energy = initial_energy;

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "tree")
		{
			Destroy(col.gameObject);
			energy = energy + eat_energy;

		}
	}
	
	// Update is called once per frame
	void Update () {
//		float forwardSpeed = Vector2.Dot(rigidbody2D.velocity, Vector2.);
//		if (forwardSpeed <= 0)
//		{
//			rigidbody2D.AddForce(new Vector2(Random.Range(-1*speed, speed), Random.Range(-1*speed, speed)));
//		}
		var speedx = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x);
		var speedy = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y);
		if (speedx <= 0.1 || speedy <= 0.1)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1*speed, speed), Random.Range(-1*speed, speed)));
		}
		if (energy <= 0)
		{
			Destroy(this.gameObject);
		}

		if (energy >= 100)
		{
			energy = initial_energy;
			if (PreyPopulationLimit() == 0)
			{
				GameObject prey = (GameObject) Instantiate(baby,transform.position, Quaternion.identity);
				prey.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(5,3));
			}
		}

	}
}
