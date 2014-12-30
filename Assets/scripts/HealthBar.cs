using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	function OnTriggerEnter ( other   Collider) {
		
		if(other.gameObject.tag == "Player")
			other.transform.root.gameObject.GetComponent(healthScript).decreaseHealth();
		
	}

}
























