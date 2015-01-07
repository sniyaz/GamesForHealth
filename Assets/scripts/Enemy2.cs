using UnityEngine;
using System.Collections;

// This enemy will teleport every 20 seconds to a location close to the player

public class Enemy2 : MonoBehaviour {

	public float maxSpeed = 30f;

	float timeLeft = 0.0f;

	public string tag = "enemy";

	public Transform target;
	public Player player;
	public GameObject poof = null;
	public float enemySpeed;
	public bool doTeleport = false;
	public float damage = 5;

	public float health = 400f;



	// Use this for initialization
	void Start () {
		player = (Player) FindObjectOfType (typeof(Player));
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{	enemySpeed = maxSpeed  * Time.deltaTime;
		//deltaTime in the next line ensures movement per second, not per frame because that would be SUPER fast

		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed); 

		timeLeft -= Time.deltaTime;

		if(Vector3.Distance(transform.position, target.transform.position) > 150){
			doTeleport = true;
		}

		if (timeLeft <= 0) {
			if (doTeleport) {
				teleport ();
				doTeleport = false;
			} 
			timeLeft = 3;
		}

		//No longer needed. Sherdil 12/30/14
		// If the enemy collides with the player, player health reduces
		//if (Vector3.Distance(transform.position, target.transform.position) < 10) {
			//player.takeDamage(damage);
//			Destroy(gameObject);
			
		//}

		if (health <= 0) {
			Destroy(gameObject);
		}

	}




	public void teleport(){
		float chance = Random.Range (0,4);

		
		// close and far determine the range at which the enemy will spawn near the player
		float close = 20f;
		float far = 30f;
		
		// Enemy will spawn in upper right
		if(chance == 0){
			Vector3 change = new Vector3 (Random.Range(close, far), Random.Range(close, far), 0);
			transform.position = target.transform.position + change;
		}
		
		// Enemy will spawn lower left
		else if(chance == 1){
			Vector3 change = new Vector3 (Random.Range(-far, -close),Random.Range(-far, -close), 0);
			transform.position = target.transform.position + change;

		}
		
		// Enemy will spwan upper left
		else if(chance == 2){
			Vector3 change = new Vector3 (Random.Range(-far, -close),Random.Range(close, far), 0);
			transform.position = target.transform.position + change;

		}
		
		// Enemy will spawn lower right
		else if(chance == 3){
			Vector3 change = new Vector3 (Random.Range(close, far),Random.Range(-far, -close), 0);
			transform.position = target.transform.position + change;

		}
		
		// The below comment generates a "poof" effect when he teleports. Looks tacky so I'm
		// Taking it out for now
		//			GameObject newPoof = (GameObject)Instantiate(poof, transform.position, Quaternion.identity);
		//			Destroy (newPoof, .5f);
		
		
		// Controls how long it takes until the next teleport
		timeLeft = 5f;
	}

	public void reduceHealth(float num){
		
		health -= num;
	}


	public void OnTriggerEnter2D(Collider2D coll){
		Debug.Log ("Welp");
		GunBullet bullet = coll.gameObject.GetComponent<GunBullet>();
		if (bullet != null) {
			Debug.Log("Gengar! :D");
			reduceHealth (20);
		}
		
	}


}