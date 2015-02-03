using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GUISkin myskin;
	public Texture2D background;
	
	void Start() {
		Screen.lockCursor = false; 
	}
	
	private void OnGUI() {
		if (PlayerControl.pause) {	
			if (GUI.Button (new Rect(5 * Screen.width / 16, 7 * Screen.height / 16, 6 * Screen.width / 16, 2 * Screen.height / 16), "Resume")) {
				PlayerControl.pause = false;
				Screen.lockCursor = true; 
			}
			
			if (GUI.Button (new Rect(5 * Screen.width / 16, 10 * Screen.height / 16, 6 * Screen.width / 16, 2 * Screen.height / 16), "Back to Menu")) {
				Application.LoadLevel("Menu");
				PlayerControl.pause = false;
			}
		}
	}
}
