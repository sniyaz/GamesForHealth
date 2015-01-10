using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float maxSpeed = 30f;
	public float health = 400f;

	public string tag = "enemy";

	public Transform target;
	public Player player;
	public float enemySpeed;
	public float damage = 5; 
	
	

	// Use this for initialization
	void Start () {
		player = (Player) FindObjectOfType (typeof(Player));
	}

	
	// Update is called once per frame
	void FixedUpdate ()
	{	enemySpeed = maxSpeed  * Time.deltaTime;
		//deltaTime in the next line ensures movement per second, not per frame because that would be SUPER fast
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed); 
		if (health <= 0) {
			Debug.Log("Dead!");
			Destroy(gameObject);
			player.enemy_count -= 1;
		} 
		// If the enemy collides with the player, player health reduces
		if (Vector3.Distance(transform.position, target.transform.position) < 10) {
			player.takeDamage(damage);
//			Destroy(gameObject);
			
		}
	}

	public void reduceHealth(float num){

		health -= num;
	}

	public void OnTriggerEnter2D(Collider2D coll){
		Debug.Log ("Welp");
		GunBullet bullet = coll.gameObject.GetComponent<GunBullet>();
		if (bullet != null) {
			Debug.Log("Got one!");
			reduceHealth (10);
		}
	
	}

}
