using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	//The following code was found at http://noobtuts.com/unity/tower-defense-game-step-4-scripting

	// fly speed
	public float speed = 10.0f;
	
	// destination set by Tower when creating the bullet
	Transform destination;    
	
	// Update is called once per frame
	void Update () {
		// destroy bullet if destination does not exist anymore
		if (destination == null) {
			Destroy(gameObject);
			return;
		}
		
		// fly towards the destination
		float stepSize = Time.deltaTime * speed;
		transform.position = Vector3.MoveTowards(transform.position, destination.position, stepSize);
		
		// reached?
		if (transform.position.Equals(destination.position)) {
//		       
//			
//			// destroy bullet
			Destroy(gameObject);
		}
	}
	
	public void setDestination(Transform v) {
		destination = v;
	}
}
