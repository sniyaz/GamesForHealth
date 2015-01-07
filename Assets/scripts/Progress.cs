using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour {
	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(40,40);
	public Vector2 size = new Vector2(60,20);
	public Texture2D emptyTex;
	public Texture2D fullTex;

	public int maxHealth = 100;
	public GameObject OuchEffect;
	
	public int Health{ get; private set;}

	
	void OnGUI() {
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}


	public void TakeDamage(int damage)
	{
		Instantiate (OuchEffect, transform.position, transform.rotation);
		Health -= damage;
	}


	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		//var healthPercent = Player.Health / (float)Player.maxHealth;
		//ForegroundSprite.localScale = new Vector3 (healthPercent, 1, 1);
		//ForegroundRenderer.color = Color.Lerp (MaxHealthColor, MinHealthColor, healthPercent);
		//barDisplay = MyControlScript.staticHealth;

		barDisplay = (Time.time - 2)*0.3f;
	}
}