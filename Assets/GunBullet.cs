using UnityEngine;
using System.Collections;

public class GunBullet : MonoBehaviour {


	public Vector2 speed = new Vector2 (0, 20);
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = speed;
	}
	
	void OnBecameInvisible(){
		Destroy (gameObject, 20);
	}
}
