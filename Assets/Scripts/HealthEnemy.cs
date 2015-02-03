using UnityEngine;
using System.Collections;

public class HealthEnemy : MonoBehaviour {
	public float health = 50;
	public float maxHealth = 50;
	Animator anim;
	public GameObject thisPlayer;
	
	// Update is called once per frame
	void Update () {
		
		print(gameObject.name + " " + health);
		if (health < 0.1) {
			thisPlayer.GetComponent<Enemy>().faint = true;
		}
	}
}
