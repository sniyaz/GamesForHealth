using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float maxSpeed = 30f;

	public Transform target;

	public float enemySpeed;
	
	

	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update ()
	{	enemySpeed = maxSpeed  * Time.deltaTime;
		//deltaTime in the next line ensures movement per second, not per frame because that would be SUPER fast
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed); 
	}

}
