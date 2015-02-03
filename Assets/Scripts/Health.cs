using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 50;
	public float maxHealth = 50;
	Animator anim;
	public GameObject thisPlayer;
	public bool isPlayer;
	
	// Update is called once per frame
	void Update () {
		print(gameObject.name + " " + health);
		if (health < 0.1) {
			if(isPlayer) {
				thisPlayer.GetComponent<PlayerControl>().faint = true;
			} else {
				thisPlayer.GetComponent<Enemy>().faint = true;
			}
		}
	}
}