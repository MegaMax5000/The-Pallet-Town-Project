using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUISkin myskin;
	public Texture2D background;

	void Start() {
		Screen.lockCursor = false; 
	}

	private void OnGUI() {
		if (background != null) {
			GUI.DrawTexture(new Rect(4 * Screen.width / 16, 2 * Screen.height / 10, 8 * Screen.width / 16, 10 * Screen.height / 16), background);
		}	               
		GUI.skin = myskin;
		if (GUI.Button (new Rect(5 * Screen.width / 16, 7 * Screen.height / 16, 6 * Screen.width / 16, 2 * Screen.height / 16), "Play Game")) {
			Application.LoadLevel("Test");
		}

		if (GUI.Button (new Rect(5 * Screen.width / 16, 10 * Screen.height / 16, 6 * Screen.width / 16, 2 * Screen.height / 16), "Exit Game")) {
			Application.Quit();
		}
	}
}
