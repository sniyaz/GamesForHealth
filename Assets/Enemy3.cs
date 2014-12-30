using UnityEngine;
using System.Collections;

// Enemy 3 will spawn double itself after a certain interval
// If it is destroyed before it can split, there will be no splitting

public class Enemy3 : MonoBehaviour {
	// splitLimit determines how many clones (including current Enemy) can come from a single original enemy
	int splitLimit = 16;
	// brethren tells how many total clones there are, including itself
	int brethren = 1;
	public GameObject splitter = null;
	// maxSpeed determines how fast this guy can go
	public float maxSpeed = 15f;
	float timeTillSplit = 5f;
	public Transform target;
	// this determines how far from the original the clone will appear
	Vector3 displacement = new Vector3 (0, 0, 0);
	

	public float enemySpeed;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemySpeed = maxSpeed  * Time.deltaTime;
		//deltaTime in the next line ensures movement per second, not per frame because that would be SUPER fast
		
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed); 
		
		timeTillSplit -= Time.deltaTime;

		if (timeTillSplit <= 0 && brethren < splitLimit) {
			brethren *= 2;
			GameObject twin = (GameObject)Instantiate(splitter, transform.position + displacement, Quaternion.identity);
			Enemy3 clone = twin.GetComponent<Enemy3>();
			clone.brethren = brethren;
			clone.maxSpeed = maxSpeed;
			clone.target = target;
			clone.splitter = splitter;
			clone.splitLimit = splitLimit;
			
			timeTillSplit = 5f;
		}
	}
}




