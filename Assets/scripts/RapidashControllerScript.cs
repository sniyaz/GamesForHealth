﻿using UnityEngine;
using System.Collections;

public class RapidashControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingLeft = false;

	public int maxHealth = 100;
	public GameObject OuchEffect;

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

		if (move > 0 && !facingLeft)
			Flip ();
		else if (move < 0 && facingLeft)
			Flip();

		float move2 = Input.GetAxis ("Vertical");
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move2 * maxSpeed);

		if (Health <= 0) {
			Destroy(gameObject);
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void TakeDamage(int damage)
	{
		Instantiate (OuchEffect, transform.position, transform.rotation);
		Health -= damage;
	}

	void OnCollisionEnter2D(Collision2D coll){
		Maze_Bad bad_hit = coll.gameObject.GetComponent<Maze_Bad>();
		if (bad_hit != null) {
			Health = 0;
		}

		Maze_Good good_hit = coll.gameObject.GetComponent<Maze_Good>();
		if (good_hit != null){
			Debug.Log("Winner!");
			Application.Quit();
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
}