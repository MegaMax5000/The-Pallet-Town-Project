using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour {
	
	public Texture healthBarBehind;
	public Texture healthBar;
	public Texture backBar;
	public GameObject thisPlayer;
	
	float healthPercent;
	float left;
	float top;
	float backWidth;
	float frontWidth;
	float height;
	
	void OnGUI () {
		//Utility.Instance.DrawHealthbar ();
		if (thisPlayer == GameObject.Find("Player")) {
			GUI.DrawTexture (new Rect (0, 0, (Screen.width / 2.5f), 28), backBar, ScaleMode.StretchToFill, true, 1.0f);
			if(thisPlayer.GetComponent<Health> ().health < 0) {
				thisPlayer.GetComponent<Health> ().health = 0;
			}
			healthPercent = thisPlayer.GetComponent<Health> ().health / thisPlayer.GetComponent<Health> ().maxHealth;
			backWidth = Screen.width / 2.5f;
			frontWidth = healthPercent * backWidth;
			left = 0;
			top = 8;
			height = 12;
			
			GUI.DrawTexture (new Rect (left, top, backWidth, height), healthBarBehind, ScaleMode.StretchToFill, true, 1.0f);
			GUI.DrawTexture (new Rect (left, top, frontWidth, height), healthBar, ScaleMode.StretchToFill, true, 1.0f);
		} else {
			GUI.DrawTexture (new Rect (Screen.width - (Screen.width / 2.5f), 0, (Screen.width / 2.5f), 28), backBar, ScaleMode.StretchToFill, true, 1.0f);
			if(thisPlayer.GetComponent<Health> ().health < 0) {
				thisPlayer.GetComponent<Health> ().health = 0;
			}
			healthPercent = thisPlayer.GetComponent<Health> ().health / thisPlayer.GetComponent<Health> ().maxHealth;
			backWidth = Screen.width / 2.5f;
			frontWidth = healthPercent * backWidth;
			left = Screen.width - backWidth;
			top = 8;
			height = 12;
			
			GUI.DrawTexture (new Rect (left, top, backWidth, height), healthBarBehind, ScaleMode.StretchToFill, true, 1.0f);
			GUI.DrawTexture (new Rect (left, top, frontWidth, height), healthBar, ScaleMode.StretchToFill, true, 1.0f);
		}
	}
}
