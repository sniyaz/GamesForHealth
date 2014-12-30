using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	
	public GameObject ammo = null;

	// attack interval
	public float interval = 0.005f;
	float timeLeft = 0.0f;
	// this is how long the tower should stay on map
	public float timeAlive = 20f; 

	// attack range
	public float range = 100.0f;


	// Use this for initialization
	void Start () {
		gameObject.collider2D.enabled = false;
		// turns on collider after 0.3 seconds. 
		// Allows the player to get out of the way instead of the tower pushing the player away
		Invoke("TurnOnCollide", 0.3f);

	}

	Enemy findClosestTarget() {
		Enemy closest = null;
		Vector2 pos = transform.position;
		
		// find all enemies
		Enemy[] enemies = (Enemy[])FindObjectsOfType(typeof(Enemy));
		if (enemies != null) {
			if (enemies.Length > 0) {
				closest = enemies[0];
				for (int i = 1; i < enemies.Length; ++i) {
					float cur = Vector3.Distance(pos, enemies[i].transform.position);
					float old = Vector3.Distance(pos, closest.transform.position);
					
					if (cur < old) {
						closest = enemies[i];
					}
				}
			}
		}
		
		return closest;
	}



	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0f) {

			Enemy target = findClosestTarget();
			// Checks if there are any enemies on board
			if(target != null){
				// Checks if enemy is in range for tower
				if (Vector3.Distance(transform.position, target.transform.position)/5 <= range) {
						
					GameObject shot = (GameObject)Instantiate(ammo, transform.position, Quaternion.identity);

					Bullet b = shot.GetComponent<Bullet>();
					b.setDestination(target.transform);

					// reset shotclock
					timeLeft = interval;
				}
			}
		}
		

		// The tower self destructs after 20 seconds 
		Destroy (gameObject, 20);


	}
	void TurnOnCollide(){
		gameObject.collider2D.enabled = true;
	}



}










