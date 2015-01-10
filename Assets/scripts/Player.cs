using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 110f;
	bool facingLeft = false;

	public float health = 300f;
	public int ammo = 200;



	public GameObject OuchEffect;
	public GameObject tower = null;
	public GameObject gunBullet;
	// refractory is the period after the player is hit. During this time, he is temporarily invincible
	public float refractory = 7f;

	//use to tell when the player has won...
	public int enemy_count;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		float move2 = Input.GetAxis ("Vertical");
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move2 * maxSpeed);
		if (Input.GetKeyDown (KeyCode.N) ) {
			dropTower();
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			shootFour();
		}
		if(Input.GetKeyDown (KeyCode.B)){
			this.transform.position = new Vector3(0,0,0);
		}
		if (health <= 0) {
			UnityEditor.EditorApplication.isPlaying = false;
			Destroy(gameObject);
			Application.Quit();
		}

		if (enemy_count == 0) {
			Debug.Log("Winner!");
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();

		}

		refractory -= Time.deltaTime;


	}


	public void dropTower (){
		GameObject g = (GameObject)Instantiate(tower, transform.position, Quaternion.identity);
	}

	public void shootFour(){

		int bulletSpeed = 40;

		GameObject up = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet up_speed = up.GetComponent<GunBullet>();
		up_speed.speed = new Vector2(0, bulletSpeed);
		up_speed.player = this.transform;


		GameObject left = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet left_speed = left.GetComponent<GunBullet>();
		left_speed.speed = new Vector2(-bulletSpeed, 0);
		left_speed.player = this.transform;

		GameObject right = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet right_speed = right.GetComponent<GunBullet>();
		right_speed.speed = new Vector2(bulletSpeed, 0);
		right_speed.player = this.transform;
		
		GameObject down = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet down_speed = down.GetComponent<GunBullet>();
		down_speed.speed = new Vector2(0, -bulletSpeed);
		down_speed.player = this.transform;

		ammo = ammo - 4;
	}
	
	
	public void OnCollisionEnter2D(Collision2D coll){
		Enemy enemy = coll.gameObject.GetComponent<Enemy>();
		if ((enemy != null) && enemy.tag == "enemy") {
			Debug.Log("Faff!");	
			health = health - 5;
		}

		Enemy2 enemy2 = coll.gameObject.GetComponent<Enemy2>();
		if ((enemy2 != null) && enemy2.tag == "enemy") {
			Debug.Log("Faff!");	
			health = health - 5;
		}

		Enemy3 enemy3 = coll.gameObject.GetComponent<Enemy3>();
			if ((enemy3 != null) && enemy3.tag == "enemy") {
				Debug.Log("Faff!");	
				health = health - 5;
			}
		}




	public void takeDamage(float damage)
	{
		//Instantiate (OuchEffect, transform.position, transform.rotation);
		if (refractory <= 0) {
			health -= damage;
			refractory = 7f;		
		}

	}




}