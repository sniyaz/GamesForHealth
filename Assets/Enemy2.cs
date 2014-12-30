using UnityEngine;
using System.Collections;

// This enemy will teleport every 20 seconds to a location close to the player

public class Enemy2 : MonoBehaviour {

	public float maxSpeed = 30f;

	float timeLeft = 0.0f;

	public Transform target;
	public GameObject poof = null;
	public float enemySpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{	enemySpeed = maxSpeed  * Time.deltaTime;
		//deltaTime in the next line ensures movement per second, not per frame because that would be SUPER fast

		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed); 

		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			float chance = Random.Range (0,4);
			print (chance);

			// close and far determine the range at which the enemy will spawn near the player
			float close = 20f;
			float far = 30f;

			// Enemy will spawn in upper right
			if(chance == 0){
				print ("GREATER THAN 0");
				Vector3 change = new Vector3 (Random.Range(close, far), Random.Range(close, far), 0);
				transform.position = target.transform.position + change;
				print (change);
			}

			// Enemy will spawn lower left
			else if(chance == 1){
				Vector3 change = new Vector3 (Random.Range(-far, -close),Random.Range(-far, -close), 0);
				transform.position = target.transform.position + change;
				print (change);
			}

			// Enemy will spwan upper left
			else if(chance == 2){
				Vector3 change = new Vector3 (Random.Range(-far, -close),Random.Range(close, far), 0);
				transform.position = target.transform.position + change;
				print (change);
			}

			// Enemy will spawn lower right
			else if(chance == 3){
				Vector3 change = new Vector3 (Random.Range(close, far),Random.Range(-far, -close), 0);
				transform.position = target.transform.position + change;
				print (change);
			}

			// The below comment generates a "poof" effect when he teleports. Looks tacky so I'm
			// Taking it out for now
//			GameObject newPoof = (GameObject)Instantiate(poof, transform.position, Quaternion.identity);
//			Destroy (newPoof, .5f);


			// Controls how long it takes until the next teleport
			timeLeft = 5f;
		} 

	}
}