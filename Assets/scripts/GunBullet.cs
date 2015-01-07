using UnityEngine;
using System.Collections;

public class GunBullet : MonoBehaviour {

	public Transform player;
	public Vector2 speed = new Vector2 (0, 20);
	public Enemy3 enemy;
	// Damage controls how strong the bullet is
	public int damage = 1;

	public string tag = "player_bullet";
	
	// Use this for initialization
	void Start () {
		gameObject.collider2D.enabled = false;
//		Invoke("TurnOnCollide", 1f);						
	}

	Enemy3 findClosestTarget() {
		Enemy3 closest = null;
		Vector2 pos = transform.position;
		
		// find all enemies
		Enemy3[] enemies = (Enemy3[])FindObjectsOfType(typeof(Enemy3));
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
	void FixedUpdate () {
		rigidbody2D.velocity = speed;

		float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
		//enemy = findClosestTarget();
		Destroy (gameObject, 5);

	}
	
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
	void TurnOnCollide(){
		gameObject.collider2D.enabled = true;
	}
}
