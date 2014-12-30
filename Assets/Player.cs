using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 110f;
	bool facingLeft = false;

	public int maxHealth = 100;
	public GameObject OuchEffect;
	public GameObject tower = null;
	public GameObject gunBullet;

	public int Health{ get; private set;}

	// Use this for initialization
	void Start () {
		Health = maxHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		float move2 = Input.GetAxis ("Vertical");
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move2 * maxSpeed);
		if (Input.GetKeyDown ("space") ) {
			dropTower();
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			print ("N PRESSED");
			shootFour();
		}

	}


	public void dropTower (){
		GameObject g = (GameObject)Instantiate(tower, transform.position, Quaternion.identity);
	}

	public void shootFour(){
		GameObject up = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet up_speed = up.GetComponent<GunBullet>();

		GameObject left = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet left_speed = left.GetComponent<GunBullet>();
		left_speed.speed = new Vector2(-6, 0);
		
		GameObject right = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet right_speed = right.GetComponent<GunBullet>();
		right_speed.speed = new Vector2(6, 0);
		
		GameObject down = (GameObject) Instantiate(gunBullet, transform.position, Quaternion.identity);
		GunBullet down_speed = down.GetComponent<GunBullet>();
		down_speed.speed = new Vector2(0, -6);
	}
	
	
	public void TakeDamage(int damage)
	{
		Instantiate (OuchEffect, transform.position, transform.rotation);
		Health -= damage;
	}
}