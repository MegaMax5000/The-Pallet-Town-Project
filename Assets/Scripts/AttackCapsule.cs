using UnityEngine;
using System.Collections;

public class AttackCapsule : MonoBehaviour {
	public float time = 20;
	public float team;
	
	private GameObject enemy;
	
	// Use this for initialization
	void Start () {
		if (team == 2) {
			enemy = GameObject.Find("Player");
		} else {
			enemy = GameObject.Find("Enemy");
		}
		time = 20;
	}
	
	// Update is called once per frame
	void Update () {
		time = time - 1;
		if (time < 0) {
			Destroy(gameObject);
		}
		
		if (Vector3.Distance(enemy.transform.position, transform.position) < 3 && team == 2) {
			enemy.GetComponent<Health>().health = enemy.GetComponent<Health>().health - 1;
			enemy.GetComponent<PlayerControl>().smallDam = true;
			Destroy(gameObject);
		} else if (Vector3.Distance(enemy.transform.position, transform.position) < 3 && team == 1) {
			enemy.GetComponent<Health>().health = enemy.GetComponent<Health>().health - 1;
			enemy.GetComponent<Enemy>().smallDam = true;
			Destroy(gameObject);
		}
	}
}
